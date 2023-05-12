using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputFloorCheckStatus : MapInputStatus
    {
        public MapInputFloorCheckStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void EnterStatus ()
        {
            if ( machine.currentFloor != null ) 
            {
                Debug.LogWarning ($"{machine.currentFloor.Root.name}");
            }
        }
    }
}