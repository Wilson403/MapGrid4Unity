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
        /// ��ǰ������״̬
        /// </summary>
        public MapInputStatus CurrentStatus { get; private set; }

        private float _currentFieldOfView = 60;
        /// <summary>
        /// ��ǰ����Ұֵ
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
        /// ����ĳ��״̬
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