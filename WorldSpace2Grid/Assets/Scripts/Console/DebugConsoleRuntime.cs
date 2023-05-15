using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace MapGrid4Unity
{
    public class DebugConsoleRuntime
    {
        public KeyCode activationKeyBind = KeyCode.F12;

        private bool _isActive;
        private string _commandStr;

        private Dictionary<string , MethodInfo> _methods = new Dictionary<string , MethodInfo> ();
        private Dictionary<string , ParameterInfo []> _methodParameters = new Dictionary<string , ParameterInfo []> ();

        private const string SEACH_BAR_CONTROL_NAME = "SearchBarTextfield";
        private const int MAX_SEARCH_RESULT_COUNT = 10;
        private const float SEARCH_RESULT_LABEL_HEIGHT = 50;

        private int _selectedEntry = -1;
        private Vector2 _scrollVec = Vector2.zero;

        private readonly List<string> _searchResult = new List<string> ();
        private readonly List<string> _searchResultOnlyMethodName = new List<string> ();

        bool _threadRunning;
        readonly Thread _thread;

        public DebugConsoleRuntime ()
        {
            _thread = new Thread (LoadMethods);
            _thread.Start ();
        }

        void LoadMethods ()
        {
            _threadRunning = true;

            IEnumerable<MethodInfo> methodsInfo = GetMethodsWith<ConsoleCmd> ();
            foreach ( MethodInfo methodInfo in methodsInfo )
            {
                _methods.Add (methodInfo.Name , methodInfo);
                _methodParameters.Add (methodInfo.Name , methodInfo.GetParameters ());
            }
            _threadRunning = false;
        }

        // [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded ()
        {

        }

        public static IEnumerable<MethodInfo> GetMethodsWith<TAttribute> (bool inherit = true)
        where TAttribute : System.Attribute
        {
            return from assemblies in System.AppDomain.CurrentDomain.GetAssemblies ()
                   from types in assemblies.GetTypes ()
                   from methods in types.GetMethods ()
                   where methods.IsDefined (typeof (TAttribute) , inherit)
                   select methods;
        }

        public void Update ()
        {
            if ( Input.GetKeyDown (activationKeyBind) )
            {
                if ( _threadRunning )
                {
                    Debug.LogWarning ("控制台还在初始化");
                    return;
                }
                _isActive = !_isActive;
            }
        }

        void InvokeMethod (string commandStr)
        {
            string [] tokens = commandStr.Split (' ');
            if ( tokens.Length < 1 ) { return; }

            string methodName = tokens [0];
            if ( _methods.ContainsKey (methodName) )
            {
                int paramStartIndex = 0;
                MethodInfo method = _methods [methodName];


                object methodTarget;
                // determine method target
                if ( method.IsStatic )
                {
                    methodTarget = this;
                    paramStartIndex = 1;
                }
                else
                {
                    Debug.LogWarning ("不支持非静态的方法");
                    return;
                }

                // parse parameters
                if ( !_methodParameters.ContainsKey (methodName) ) { return; }
                ParameterInfo [] paramInfos = _methodParameters [methodName];
                object [] methodParams = new object [paramInfos.Length];
                for ( int i = 0 ; i < paramInfos.Length ; i++ )
                {
                    ParameterInfo paramInfo = paramInfos [i];

                    if ( tokens.Length <= paramStartIndex + i )
                    {
                        Debug.LogWarning ("uConsole: not enough parameters provided");
                        break;
                    }
                    string paramStr = tokens [paramStartIndex + i];

                    if ( paramInfo.ParameterType == typeof (int) )
                    {
                        methodParams [i] = int.Parse (paramStr);
                    }
                    else if ( paramInfo.ParameterType == typeof (float) )
                    {
                        methodParams [i] = float.Parse (paramStr);
                    }
                    else if ( paramInfo.ParameterType == typeof (string) )
                    {
                        methodParams [i] = paramStr;
                    }
                }

                if ( methodTarget != null )
                {
                    method.Invoke (methodTarget , methodParams);
                }
            }
        }

        void RefreshSearchResult (string commandStr)
        {
            foreach ( KeyValuePair<string , MethodInfo> method in _methods )
            {
                if ( method.Key.ToLower ().Contains (commandStr.ToLower ()) && !_searchResultOnlyMethodName.Contains (method.Key) )
                {
                    _searchResultOnlyMethodName.Add (method.Key);

                    string desc = string.IsNullOrEmpty (method.Value.GetCustomAttribute<ConsoleCmd> ().Desc) ? "" : $"({method.Value.GetCustomAttribute<ConsoleCmd> ().Desc})";
                    _searchResult.Add ($"{method.Key}{desc}");
                }
            }
        }

        void NavigateSearchResult (KeyCode dirKey)
        {
            if ( dirKey == KeyCode.UpArrow )
            {
                _selectedEntry--;
                if ( _selectedEntry < 0 )
                {
                    _selectedEntry = _searchResult.Count - 1;
                }
            }
            else if ( dirKey == KeyCode.DownArrow )
            {
                _selectedEntry++;
                if ( _selectedEntry >= _searchResult.Count )
                {
                    _selectedEntry = 0;
                }
            }
            _scrollVec.y = _selectedEntry * SEARCH_RESULT_LABEL_HEIGHT;
        }

        void CloseConsole ()
        {
            _isActive = false;
            _selectedEntry = -1;
            _commandStr = string.Empty;
            _searchResult.Clear ();
            _searchResultOnlyMethodName.Clear ();
        }

        public void OnGUI ()
        {
            if ( _isActive )
            {
                GUI.FocusControl (SEACH_BAR_CONTROL_NAME);

                GUI.SetNextControlName (SEACH_BAR_CONTROL_NAME);
                GUIStyle searchBarStyle = new GUIStyle (GUI.skin.textField);
                GUI.skin.textField.fontSize = 32;
                searchBarStyle.fixedHeight = 0;
                searchBarStyle.fixedHeight = searchBarStyle.CalcHeight (new GUIContent (_commandStr) , Screen.width);
                _commandStr = GUI.TextField (new UnityEngine.Rect (0 , Screen.height - searchBarStyle.fixedHeight , Screen.width , searchBarStyle.fixedHeight) , _commandStr , searchBarStyle);

                if ( GUI.changed )
                {
                    if ( !string.IsNullOrEmpty (_commandStr) )
                    {
                        // toggle search bar 
                        if ( ( KeyCode ) _commandStr.Last () == activationKeyBind )
                        {
                            CloseConsole ();
                        }
                        else
                        {
                            RefreshSearchResult (_commandStr);
                        }
                    }
                    else
                    {
                        _searchResult.Clear ();
                        _searchResultOnlyMethodName.Clear ();
                    }

                    // navigate through search result
                    if ( Event.current.keyCode == KeyCode.UpArrow || Event.current.keyCode == KeyCode.DownArrow )
                    {
                        NavigateSearchResult (Event.current.keyCode);
                    }
                }

                // keyboard interaction
                if ( Event.current.type == EventType.KeyUp )
                {
                    // excecute command
                    if ( Event.current.keyCode == KeyCode.Return )
                    {
                        InvokeMethod (_commandStr);

                        CloseConsole ();
                    }
                    // select search result
                    else if ( Event.current.keyCode == KeyCode.Tab )
                    {
                        if ( _searchResult.Count <= _selectedEntry )
                        {
                            return;
                        }
                        _commandStr = _searchResultOnlyMethodName [_selectedEntry];
                    }
                }

                // search result scrollview
                float searchResultHeight = SEARCH_RESULT_LABEL_HEIGHT * _searchResult.Count;
                float clampedResultHeight = Mathf.Clamp (searchResultHeight , 0 , MAX_SEARCH_RESULT_COUNT * SEARCH_RESULT_LABEL_HEIGHT);
                float scrollStartY = Screen.height - searchBarStyle.fixedHeight - clampedResultHeight;
                GUI.Box (new UnityEngine.Rect (0 , scrollStartY , Screen.width , clampedResultHeight) , string.Empty);
                GUI.skin.label.fontSize = 24;
                _scrollVec = GUI.BeginScrollView (new UnityEngine.Rect (0 , scrollStartY , Screen.width , clampedResultHeight) , _scrollVec , new UnityEngine.Rect (0 , 0 , Screen.width , searchResultHeight));
                for ( int i = 0 ; i < _searchResult.Count ; i++ )
                {
                    GUI.color = _selectedEntry == i ? Color.yellow : Color.white;
                    GUI.Label (new UnityEngine.Rect (0 , i * SEARCH_RESULT_LABEL_HEIGHT , Screen.width , SEARCH_RESULT_LABEL_HEIGHT) , _searchResult [i]);
                }
                GUI.EndScrollView ();
            }
        }
    }
}