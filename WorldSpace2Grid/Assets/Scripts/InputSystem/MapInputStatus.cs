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
        /// 多点触摸开始
        /// </summary>
        /// <param name="touchPos1"></param>
        /// <param name="touchPos2"></param>
        public virtual void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {

        }

        /// <summary>
        /// 多点触摸移动
        /// </summary>
        /// <param name="touchPos1"></param>
        /// <param name="touchPos2"></param>
        public virtual void MultiTouchMove (Vector2 touchPos1 , Vector2 touchPos2)
        {

        }

        /// <summary>
        /// 多点触摸结束
        /// </summary>
        public virtual void MultiTouchEnd ()
        {

        }
    }
}