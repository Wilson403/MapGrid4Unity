using UnityEngine;

namespace MapGrid4Unity
{
    /// <summary>
    /// �����������
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