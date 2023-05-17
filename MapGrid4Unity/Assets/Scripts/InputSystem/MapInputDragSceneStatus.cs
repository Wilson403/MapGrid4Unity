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

            var offset = new Vector3 (touchPos.x , 0 , touchPos.y) - new Vector3 (_initTouchPos.x , 0 , _initTouchPos.y);
            var finalPos = _initScenePos - offset;
            Camera.main.transform.parent.position = new Vector3 (finalPos.x , Camera.main.transform.parent.position.y , finalPos.z);
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