using UnityEngine;

namespace MapGrid4Unity
{
    /// <summary>
    /// 生命周期入口
    /// </summary>
    public class MapRuntime : MonoBehaviour
    {
        private void Start ()
        {
            MapMgr.Ins.CreateHexGrid ();
        }

        private void Update ()
        {
            MapMgr.Ins.Update ();
        }
    }
}