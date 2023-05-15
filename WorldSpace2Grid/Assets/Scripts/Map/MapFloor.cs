using System.Collections;
using UnityEngine;

namespace MapGrid4Unity
{
    public class MapFloor : MapItem
    {
        public MapFloor (Vector3 gridPos) : base (gridPos)
        {

        }

        public override void CreateInstance (Transform parent)
        {
            if ( Root != null )
            {
                return;
            }
            Root = GameObject.Instantiate (Resources.Load ("Cube") , parent) as GameObject;
            Root.transform.position = worldPos;

            //随便设置一个条件生成子对象
            if (true|| gridPos.x / 2 != 0 && gridPos.z / 2 != 0 )
            {
                MapRuntime.Ins.StartCoroutine (DelayCreateChildItem ());
            }
        }

        IEnumerator DelayCreateChildItem ()
        {
            ChildItem = new MapBallItem (new Vector3 (gridPos.x , 10 , gridPos.z));
            ChildItem.CreateInstance (Root.transform);
            yield return new WaitForEndOfFrame ();
        }
    }
}