using UnityEngine;

namespace WorldSpace2Grid
{
    public class StartDemo : SingletonMonoBehaviour<StartDemo>
    {
        public Transform cubeContent;
        public Camera standardCamera;
        DebugConsoleRuntime _debugConsoleRuntime;

        private void Awake ()
        {
            Debug.Log ("�����ÿ���̨��F12�ɿ���");
            _debugConsoleRuntime = new DebugConsoleRuntime ();
            MapMgr.Ins.GeneratedFloor ();
        }

        private void Update ()
        {
            _debugConsoleRuntime.Update ();
            MapMgr.Ins.Update ();
        }

        private void OnGUI ()
        {
            _debugConsoleRuntime.OnGUI ();
        }
    }
}