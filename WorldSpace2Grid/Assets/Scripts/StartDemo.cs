using UnityEngine;
using UnityEngine.UI;

namespace WorldSpace2Grid
{
    public class StartDemo : MonoBehaviour
    {
        DebugConsoleRuntime _debugConsoleRuntime;
        public Image image;

        private void Awake ()
        {
            Debug.Log ("已启用控制台，F12可开启");
            _debugConsoleRuntime = new DebugConsoleRuntime ();
        }

        private void Update ()
        {
            _debugConsoleRuntime.Update ();
            MapMgr.Ins.Update ();
            image.transform.localScale = new Vector3(MapMgr.Ins.mapInputStatusMachine.CurrentScaleValue, MapMgr.Ins.mapInputStatusMachine.CurrentScaleValue, MapMgr.Ins.mapInputStatusMachine.CurrentScaleValue);
        }

        private void OnGUI ()
        {
            _debugConsoleRuntime.OnGUI ();
        }
    }
}