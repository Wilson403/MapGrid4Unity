using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputStatusMachine
    {
        public readonly MapInputIdleStatus mapInputIdleStatus;
        public readonly MapInputScaleStatus mapInputScaleStatus;
        public readonly MapInputDragSceneStatus mapInputDragSceneStatus;
        public readonly MapInputDragMapItemStatus mapInputDragMapItemStatus;
        public readonly MapInputFloorCheckStatus mapInputFloorCheckStatus;

        public MapFloor currentFloor;

        /// <summary>
        /// 当前的输入状态
        /// </summary>
        public MapInputStatus CurrentStatus { get; private set; }

        private float _currentFieldOfView = 60;
        /// <summary>
        /// 当前的视野值
        /// </summary>
        public float CurrentFieldOfView
        {
            get
            {
                return _currentFieldOfView;
            }
            set
            {
                _currentFieldOfView = value;
            }
        }

        public MapInputStatusMachine ()
        {
            mapInputIdleStatus = new MapInputIdleStatus (this);
            mapInputScaleStatus = new MapInputScaleStatus (this);
            mapInputDragSceneStatus = new MapInputDragSceneStatus (this);
            mapInputDragMapItemStatus = new MapInputDragMapItemStatus (this);
            mapInputFloorCheckStatus = new MapInputFloorCheckStatus (this);
            EnterStatus (mapInputIdleStatus);
        }

        /// <summary>
        /// 进入某个状态
        /// </summary>
        /// <param name="newStatus"></param>
        public void EnterStatus (MapInputStatus newStatus)
        {
            if ( newStatus == null )
            {
                return;
            }

            if ( newStatus == CurrentStatus )
            {
                return;
            }

            if ( CurrentStatus != null )
            {
                CurrentStatus.ExitStatus ();
            }

            CurrentStatus = newStatus;
            CurrentStatus.EnterStatus ();
            Debug.Log ($"EnterStatus:[{newStatus}]");
        }
    }
}