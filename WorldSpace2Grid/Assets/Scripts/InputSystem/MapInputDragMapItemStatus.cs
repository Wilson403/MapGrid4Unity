using UnityEngine;

namespace MapGrid4Unity
{
    public class MapInputDragMapItemStatus : MapInputStatus
    {
        private Vector3 _initItemPos;
        private Vector2 _finalTouchPos;

        public MapInputDragMapItemStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void EnterStatus ()
        {
            _initItemPos = machine.currentFloor.ChildItem.Root.transform.position;
        }

        public override void TouchMove (Vector2 touchPos)
        {
            _finalTouchPos = touchPos;
            if ( machine.currentFloor != null && machine.currentFloor.ChildItem != null )
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (touchPos.x , touchPos.y , Camera.main.transform.position.y));
                machine.currentFloor.ChildItem.Root.transform.position = new Vector3 (worldPos.x , machine.currentFloor.ChildItem.Root.transform.position.y , worldPos.z);
                return;
            }
            machine.EnterStatus (machine.mapInputDragSceneStatus);
        }

        public override void TouchEnd ()
        {
            var clickFloor = MapMgr.Ins.MatchMapFloor (_finalTouchPos);
            if ( clickFloor != null && clickFloor.ChildItem == null )
            {
                machine.currentFloor.ChildItem.Root.transform.SetParent (clickFloor.Root.transform);
                machine.currentFloor.ChildItem.Root.transform.position = new Vector3 (clickFloor.Root.transform.position.x , 10 , clickFloor.Root.transform.position.z);
            }
            else 
            {
                machine.currentFloor.ChildItem.Root.transform.position = _initItemPos;
            }
            machine.EnterStatus (machine.mapInputIdleStatus);
        }
    }
}