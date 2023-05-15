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

            //�����⵽�˵ؿ飬����ؿ���
            if ( clickFloor != null )
            {
                machine.currentFloor = clickFloor;
                machine.EnterStatus (machine.mapInputFloorCheckStatus);
                machine.CurrentStatus.TouchStart (touchPos);
                return;
            }

            //Ĭ�Ͻ�����ק������״̬
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