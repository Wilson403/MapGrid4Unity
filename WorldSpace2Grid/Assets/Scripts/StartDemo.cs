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
            Debug.Log ("已启用控制台，F12可开启");
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