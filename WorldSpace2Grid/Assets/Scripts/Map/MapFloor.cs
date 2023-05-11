using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapFloor : MapItem
    {
        public GameObject Root { get; private set; }

        public MapFloor (Vector2 gridPos) : base (gridPos)
        {

        }

        public override void CreateInstance (Transform parent)
        {
            if ( Root != null )
            {
                return;
            }
            Root = GameObject.Instantiate (Resources.Load ("Cube") , parent) as GameObject;
            Root.transform.position = new Vector3 (worldPos.x , 0 , worldPos.y);
        }
    }
}