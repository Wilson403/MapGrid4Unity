using UnityEngine;

namespace MapGrid4Unity
{
    public class MapInputDragSceneStatus : MapInputStatus
    {
        private Vector3 _initTouchPos;
        private Vector3 _initScenePos;

        public MapInputDragSceneStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void TouchStart (Vector2 touchPos)
        {
            _initTouchPos = touchPos;
            _initScenePos = Camera.main.transform.parent.position;
        }

        public override void TouchMove (Vector2 touchPos)
        {
            if ( touchPos.x == _initTouchPos.x && touchPos.y == _initTouchPos.y )
            {
                return;
            }
            var finalPos = _initScenePos + new Vector3 (touchPos.x , touchPos.y , 0) - _initTouchPos;
            Camera.main.transform.parent.position = new Vector3 (-finalPos.x , Camera.main.transform.parent.position.y , -finalPos.y);
        }

        public override void TouchEnd ()
        {
            machine.EnterStatus (machine.mapInputIdleStatus);
        }

        public override void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            machine.EnterStatus (machine.mapInputScaleStatus);
            machine.CurrentStatus.MultiTouchStart (touchPos1 , touchPos2);
        }
    }
}