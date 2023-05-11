using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputScaleStatus : MapInputStatus
    {
        private Vector2 _initTouchPos1;
        private Vector2 _initTouchPos2;
        private float _initFieldOfView;

        public MapInputScaleStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void EnterStatus ()
        {
            base.EnterStatus ();
            _initFieldOfView = machine.CurrentFieldOfView;
        }

        public override void TouchStart (Vector2 touchPos)
        {
            //多点触摸变到单点触摸，回到默认状态重新检测
            machine.EnterStatus (machine.mapInputIdleStatus);
            machine.CurrentStatus.TouchStart (touchPos);
        }

        public override void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            _initTouchPos1 = touchPos1;
            _initTouchPos2 = touchPos2;
        }

        public override void MultiTouchMove (Vector2 touchPos1 , Vector2 touchPos2)
        {
            var scaleNum = ( touchPos1 - touchPos2 ).magnitude / ( _initTouchPos1 - _initTouchPos2 ).magnitude;
            machine.CurrentFieldOfView = scaleNum * _initFieldOfView;
            Camera.main.fieldOfView = machine.CurrentFieldOfView;
        }

        public override void MultiTouchEnd ()
        {
            machine.EnterStatus (machine.mapInputIdleStatus);
        }
    }
}