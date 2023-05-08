using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputStatusMachine
    {
        public readonly MapInputIdleStatus mapInputIdleStatus;
        public readonly MapInputScaleStatus mapInputScaleStatus;

        /// <summary>
        /// ��ǰ������״̬
        /// </summary>
        public MapInputStatus CurrentStatus { get; private set; }

        private float _currentScaleValue = 1;
        /// <summary>
        /// ��ǰ������ָ
        /// </summary>
        public float CurrentScaleValue 
        {
            get 
            {
                return _currentScaleValue;
            }
            set 
            {
                _currentScaleValue = value;
            }
        }

        public MapInputStatusMachine ()
        {
            mapInputIdleStatus = new MapInputIdleStatus (this);
            mapInputScaleStatus = new MapInputScaleStatus (this);
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
        }
    }
}