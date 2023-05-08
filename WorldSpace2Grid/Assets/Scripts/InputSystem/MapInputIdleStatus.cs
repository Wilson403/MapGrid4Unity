using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputIdleStatus : MapInputStatus
    {
        public MapInputIdleStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            machine.EnterStatus (machine.mapInputScaleStatus);
            machine.CurrentStatus.MultiTouchStart (touchPos1 , touchPos2);
        }

        public override void MultiTouchMove (Vector2 touchPos1 , Vector2 touchPos2)
        {

        }
    }
}