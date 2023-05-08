using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputScaleStatus : MapInputStatus
    {
        private Vector2 _initTouchPos1;
        private Vector2 _initTouchPos2;
        private float _initScale;

        public MapInputScaleStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void EnterStatus ()
        {
            base.EnterStatus ();
            _initScale = machine.CurrentScaleValue;
        }

        public override void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            _initTouchPos1 = touchPos1;
            _initTouchPos2 = touchPos2;
        }

        public override void MultiTouchMove (Vector2 touchPos1 , Vector2 touchPos2)
        {
            var scaleNum = ( touchPos1 - touchPos2 ).magnitude / ( _initTouchPos1 - _initTouchPos2 ).magnitude;
            machine.CurrentScaleValue = scaleNum * _initScale;
        }

        public override void MultiTouchEnd ()
        {
            machine.EnterStatus (machine.mapInputIdleStatus);
        }
    }
}