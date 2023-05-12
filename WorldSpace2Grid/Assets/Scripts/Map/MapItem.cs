using UnityEngine;

namespace WorldSpace2Grid
{
    public abstract class MapItem
    {
        public readonly Vector2 gridPos;
        public readonly Vector3 worldPos;

        public MapItem (Vector2 gridPos)
        {
            this.gridPos = gridPos;
            this.worldPos = MapMgr.Ins.grid2WorldSpaceMatri.MultiplyPoint (new Vector4 (gridPos.x , 0 , gridPos.y , 1));
        }

        public abstract void CreateInstance (Transform parent);

        public void IsClick ()
        {

        }
    }
}