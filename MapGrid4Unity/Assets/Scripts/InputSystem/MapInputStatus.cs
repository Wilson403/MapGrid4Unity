using UnityEngine;

namespace MapGrid4Unity
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
        /// ������ʼ
        /// </summary>
        /// <param name="touchPos"></param>
        public virtual void TouchStart (Vector2 touchPos) 
        {

        }

        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <param name="touchPos"></param>
        public virtual void TouchMove (Vector2 touchPos) 
        {

        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual void TouchEnd () 
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