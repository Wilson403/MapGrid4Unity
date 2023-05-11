using UnityEngine;

namespace WorldSpace2Grid
{
    public abstract class MapItem
    {
        public readonly Vector2 gridPos;
        public readonly Vector2 worldPos;

        public MapItem (Vector2 gridPos)
        {
            this.gridPos = gridPos;
            this.worldPos = MapMgr.Ins.grid2WorldSpaceMatri.MultiplyPoint (new Vector4 (gridPos.x , gridPos.y , 0 , 1));
        }

        public abstract void CreateInstance (Transform parent);
    }
}