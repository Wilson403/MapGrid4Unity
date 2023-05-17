using UnityEngine;

namespace MapGrid4Unity
{
    public partial class MapMgr : SafeSingleton<MapMgr>
    {
        public readonly Matrix4x4 grid2WorldSpaceMatri;
        public readonly Matrix4x4 worldSpace2Grid;
        public HexGrid HexGrid { get; private set; }

        public MapMgr ()
        {
            Vector4 x = new Vector4 (-10 , 0 , 10 , 0);
            Vector4 y = new Vector4 (0 , 1 , 0 , 0);
            Vector4 z = new Vector4 (10 , 0 , 10 , 0);
            Vector4 w = new Vector4 (0 , 0 , 0 , 1);
            grid2WorldSpaceMatri = new Matrix4x4 (x , y , z , w);
            worldSpace2Grid = grid2WorldSpaceMatri.inverse;
        }

        public void Update ()
        {
            OnCheckInput ();
        }

        public void CreateHexGrid () 
        {
            HexGrid = new HexGrid ();
        }
    }
}