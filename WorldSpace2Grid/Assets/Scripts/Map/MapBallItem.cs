using UnityEngine;

namespace MapGrid4Unity
{
    public class MapBallItem : MapItem
    {
        public MapBallItem (Vector3 gridPos) : base (gridPos)
        {

        }

        public override void CreateInstance (Transform parent)
        {
            if ( Root != null )
            {
                return;
            }
            Root = GameObject.Instantiate (Resources.Load ("Sphere") , parent) as GameObject;
            Root.transform.position = worldPos;
        }
    }
}