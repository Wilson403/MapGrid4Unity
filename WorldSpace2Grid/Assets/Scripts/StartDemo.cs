using UnityEngine;

namespace WorldSpace2Grid
{
    public class StartDemo : SingletonMonoBehaviour<StartDemo>
    {
        public Transform cubeContent;
        DebugConsoleRuntime _debugConsoleRuntime;

        private void Awake ()
        {
            Debug.Log ("已启用控制台，F12可开启");
            _debugConsoleRuntime = new DebugConsoleRuntime ();
            GenMapItem ();
        }

        private void Update ()
        {
            _debugConsoleRuntime.Update ();
            MapMgr.Ins.Update ();
        }

        void GenMapItem ()
        {
            for ( int i = 0 ; i < 10 ; i++ )
            {
                for ( int j = 0 ; j < 10 ; j++ )
                {
                    MapMgr.Ins.GeneratedMapItem (new UnityEngine.Vector2 (i , j) , cubeContent);
                }
            }
        }

        private void OnGUI ()
        {
            _debugConsoleRuntime.OnGUI ();
        }
    }
}