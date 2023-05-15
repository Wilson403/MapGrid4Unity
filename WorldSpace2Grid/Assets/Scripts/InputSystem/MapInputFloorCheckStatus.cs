using UnityEngine;

namespace MapGrid4Unity
{
    public class MapInputFloorCheckStatus : MapInputStatus
    {
        public MapInputFloorCheckStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void TouchStart (Vector2 touchPos)
        {
            if ( machine.currentFloor != null )
            {
                if ( machine.currentFloor.ChildItem == null )
                {
                    machine.EnterStatus (machine.mapInputDragSceneStatus);
                    machine.CurrentStatus.TouchStart (touchPos);
                }
                else
                {
                    machine.EnterStatus (machine.mapInputDragMapItemStatus);
                }
                return;
            }
            machine.EnterStatus (machine.mapInputIdleStatus);
        }
    }
}