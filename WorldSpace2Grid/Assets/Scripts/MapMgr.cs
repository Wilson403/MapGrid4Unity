using UnityEngine;

namespace WorldSpace2Grid
{
    public partial class MapMgr : SafeSingleton<MapMgr>
    {
        Matrix4x4 _grid2WorldSpaceMatri;
        Matrix4x4 _worldSpace2Grid;

        public MapMgr ()
        {
            Vector4 x = new Vector4 (-1 , 1 , 0 , 0);
            Vector4 y = new Vector4 (1 , 1 , 0 , 0);
            Vector4 z = new Vector4 (0 , 0 , 1 , 0);
            Vector4 w = new Vector4 (0 , 0 , 0 , 1);
            _grid2WorldSpaceMatri = new Matrix4x4 (x , y , z , w);
            _worldSpace2Grid = _grid2WorldSpaceMatri.inverse;
        }

        public void Update ()
        {
            OnCheckInput ();
        }

        public void GeneratedMapItem (Vector2 v2)
        {
            var res = _grid2WorldSpaceMatri.MultiplyPoint (new Vector4 (v2.x , v2.y , 0 , 1));
            var cube = GameObject.Instantiate (Resources.Load ("Cube")) as GameObject;
            cube.transform.position = new Vector3 (res.x , 0 , res.y);
        }
    }
}