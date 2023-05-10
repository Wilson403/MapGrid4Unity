using UnityEngine;

namespace WorldSpace2Grid
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
            _initTouchPos = machine.mapRoot.parent.worldToLocalMatrix.MultiplyPoint (Camera.main.ScreenToWorldPoint (new Vector3 (touchPos.x , 0 , touchPos.y)));
            _initScenePos = machine.mapRoot.localPosition;
        }

        public override void TouchMove (Vector2 touchPos)
        {
            var currentPos = machine.mapRoot.parent.worldToLocalMatrix.MultiplyPoint (Camera.main.ScreenToWorldPoint (new Vector3 (touchPos.x , 0 , touchPos.y)));
            var finalPos = _initScenePos + currentPos - _initTouchPos;
            machine.mapRoot.localPosition = new Vector3 (finalPos.x , machine.mapRoot.localPosition.y , finalPos.z);
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