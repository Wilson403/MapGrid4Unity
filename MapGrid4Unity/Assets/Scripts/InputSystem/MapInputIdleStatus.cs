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
            Ray inputRay = Camera.main.ScreenPointToRay (touchPos);
            RaycastHit hit;
            if ( Physics.Raycast (inputRay , out hit) )
            {
                var hexCoordinates = HexCoordinates.FromPostion (hit.point);
                var hexCell = MapMgr.Ins.HexGrid.GetHexCell (hexCoordinates);
                hexCell.color = new Color (0.5f , 1 , 0 , 1);
                MapMgr.Ins.HexGrid.Refresh ();
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