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
            Debug.Log ("�����ÿ���̨��F12�ɿ���");
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