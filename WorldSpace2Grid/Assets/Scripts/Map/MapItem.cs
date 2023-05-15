using UnityEngine;

namespace MapGrid4Unity
{
    public abstract class MapItem
    {
        public readonly Vector3 gridPos;
        public readonly Vector3 worldPos;

        public MapItem ChildItem { get; protected set; }
        public GameObject Root { get; protected set; }

        public MapItem (Vector3 gridPos)
        {
            this.gridPos = gridPos;
            this.worldPos = MapMgr.Ins.grid2WorldSpaceMatri.MultiplyPoint (new Vector4 (gridPos.x , gridPos.y , gridPos.z , 1));
        }

        public abstract void CreateInstance (Transform parent);
    }
}