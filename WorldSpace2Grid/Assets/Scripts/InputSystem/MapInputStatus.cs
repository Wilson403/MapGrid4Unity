using UnityEngine;

namespace WorldSpace2Grid
{
    public class MapInputStatus
    {
        protected MapInputStatusMachine machine;

        public MapInputStatus (MapInputStatusMachine machine)
        {
            this.machine = machine;
        }

        public virtual void EnterStatus ()
        {

        }

        public virtual void ExitStatus ()
        {

        }

        /// <summary>
        /// ��㴥����ʼ
        /// </summary>
        /// <param name="touchPos1"></param>
        /// <param name="touchPos2"></param>
        public virtual void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {

        }

        /// <summary>
        /// ��㴥���ƶ�
        /// </summary>
        /// <param name="touchPos1"></param>
        /// <param name="touchPos2"></param>
        public virtual void MultiTouchMove (Vector2 touchPos1 , Vector2 touchPos2)
        {

        }

        /// <summary>
        /// ��㴥������
        /// </summary>
        public virtual void MultiTouchEnd ()
        {

        }
    }
}