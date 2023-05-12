using System;
using System.Net;
using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputIdleStatus : MapInputStatus
    {
        public MapInputIdleStatus (MapInputStatusMachine machine) : base (machine)
        {

        }

        public override void TouchStart (Vector2 touchPos)
        {
            Vector3 mousePos = new Vector3 (touchPos.x , touchPos.y , Camera.main.transform.position.y);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint (mousePos);
            worldPos = new Vector3 (worldPos.x , 0 , worldPos.z);

            MapFloor clickFloor = null;
            foreach ( MapFloor floor in MapMgr.Ins.mapFloors )
            {
                float length = Vector3.Distance (floor.worldPos , worldPos);
                if ( length <= 5 )
                {
                    clickFloor = floor;
                    break;
                }
            }

            //�����⵽�˵ؿ飬����ؿ���
            if ( clickFloor != null )
            {
                machine.currentFloor = clickFloor;
                machine.EnterStatus (machine.mapInputFloorCheckStatus);
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