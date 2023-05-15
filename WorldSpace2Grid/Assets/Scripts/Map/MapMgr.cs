using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGrid4Unity
{
    public partial class MapMgr : SafeSingleton<MapMgr>
    {
        public readonly Matrix4x4 grid2WorldSpaceMatri;
        public readonly Matrix4x4 worldSpace2Grid;
        public readonly List<MapFloor> mapFloors;

        public MapMgr ()
        {
            Vector4 x = new Vector4 (-10 , 0 , 10 , 0);
            Vector4 y = new Vector4 (0 , 1 , 0 , 0);
            Vector4 z = new Vector4 (10 , 0 , 10 , 0);
            Vector4 w = new Vector4 (0 , 0 , 0 , 1);
            grid2WorldSpaceMatri = new Matrix4x4 (x , y , z , w);
            worldSpace2Grid = grid2WorldSpaceMatri.inverse;
            mapFloors = new List<MapFloor> (100);
        }

        public void Update ()
        {
            OnCheckInput ();
        }

        /// <summary>
        /// Æ¥ÅäµØ¿é
        /// </summary>
        /// <param name="touchPos"></param>
        /// <returns></returns>
        public MapFloor MatchMapFloor (Vector2 touchPos)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (touchPos.x , touchPos.y , Camera.main.transform.parent.position.y));
            worldPos.y = 0;
            MapFloor clickFloor = null;
            foreach ( MapFloor floor in mapFloors )
            {
                float length = Vector3.Distance (floor.worldPos , worldPos);
                if ( length <= 5 )
                {
                    clickFloor = floor;
                    break;
                }
            }
            return clickFloor;
        }

        public void GeneratedFloor ()
        {
            for ( int i = 0 ; i < 10 ; i++ )
            {
                for ( int j = 0 ; j < 10 ; j++ )
                {
                    mapFloors.Add (new MapFloor (new Vector3 (i , 0 , j)));
                }
            }
            MapRuntime.Ins.StartCoroutine (DelayCreateFloor ());
        }

        IEnumerator DelayCreateFloor ()
        {
            for ( int i = 0 ; i < mapFloors.Count ; i++ )
            {
                mapFloors [i].CreateInstance (MapRuntime.Ins.content);
                mapFloors [i].Root.name = $"Floor:[{mapFloors [i].gridPos}]";
                yield return new WaitForEndOfFrame ();
            }
        }
    }
}