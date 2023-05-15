using UnityEngine;

namespace MapGrid4Unity
{
    public class MapInputIdleStatus : MapInputStatus
    {
        public MapInputIdleStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void TouchStart (Vector2 touchPos)
        {
            var clickFloor = MapMgr.Ins.MatchMapFloor (touchPos);

            //如果检测到了地块，进入地块检查
            if ( clickFloor != null )
            {
                machine.currentFloor = clickFloor;
                machine.EnterStatus (machine.mapInputFloorCheckStatus);
                machine.CurrentStatus.TouchStart (touchPos);
                return;
            }

            //默认进入拖拽场景的状态
            machine.EnterStatus (machine.mapInputDragSceneStatus);
            machine.CurrentStatus.TouchStart (touchPos);
        }

        public override void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            machine.EnterStatus (machine.mapInputScaleStatus);
            machine.CurrentStatus.MultiTouchStart (touchPos1 , touchPos2);
        }
    }
}