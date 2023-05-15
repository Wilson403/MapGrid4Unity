using UnityEngine;

namespace MapGrid4Unity
{
    public class MapRuntime : SingletonMonoBehaviour<MapRuntime>
    {
        public Transform content;
        public Camera standardCamera;
        public HexMesh hexMesh;
        DebugConsoleRuntime _debugConsoleRuntime;

        private void Awake ()
        {
            Debug.Log ("已启用控制台，F12可开启");
            _debugConsoleRuntime = new DebugConsoleRuntime ();

            new HexGrid ();

            //MapMgr.Ins.GeneratedFloor ();
        }

        private void Update ()
        {
            _debugConsoleRuntime.Update ();
            //MapMgr.Ins.Update ();
        }

        private void OnGUI ()
        {
            _debugConsoleRuntime.OnGUI ();
        }
    }
}