using UnityEngine;

namespace WorldSpace2Grid
{
    public partial class MapMgr : SafeSingleton<MapMgr>
    {
        public readonly MapInputStatusMachine mapInputStatusMachine = new MapInputStatusMachine ();
        private Vector2 _multiTouchPos1;
        private Vector2 _multiTouchPos2;
        private Vector2 _singleTouchPos;

        void OnCheckInput ()
        {
            if ( Input.GetMouseButton (0) )
            {
                //�����޷�������ϵͳ�£�ʹ��LeftAlt��ģ���ָ����
                if ( Input.touchCount == 0 )
                {
                    if ( Input.GetKey (KeyCode.LeftAlt) )
                    {
                        _multiTouchPos1 = new Vector2 (Input.mousePosition.x , Input.mousePosition.y);
                        _multiTouchPos2 = new Vector2 (-Input.mousePosition.x , -Input.mousePosition.y);
                        MultiTouchStart (_multiTouchPos1 , _multiTouchPos2);
                        return;
                    }
                    else
                    {
                        _singleTouchPos = new Vector2 (Input.mousePosition.x , Input.mousePosition.y);
                        TouchStart (_singleTouchPos);
                        return;
                    }
                }

                //���Դ�����ϵͳ����
                else
                {
                    if ( Input.touchCount == 1 )
                    {
                        _singleTouchPos = Input.GetTouch (0).position;
                        TouchStart (_singleTouchPos);
                        return;
                    }

                    if ( Input.touchCount > 1 )
                    {
                        _multiTouchPos1 = Input.GetTouch (0).position;
                        _multiTouchPos2 = Input.GetTouch (1).position;
                        MultiTouchStart (_multiTouchPos1 , _multiTouchPos2);
                        return;
                    }
                }
            }

            TouchEnd ();
            MultiTouchEnd ();
        }

        private bool _isTouchStart = false;
        /// <summary>
        /// ������ʼ
        /// </summary>
        /// <param name="touchPos"></param>
        void TouchStart (Vector2 touchPos)
        {
            if ( !_isTouchStart )
            {
                mapInputStatusMachine.CurrentStatus.TouchStart (touchPos);
                _isTouchStart = true;
            }
            else
            {
                mapInputStatusMachine.CurrentStatus.TouchMove (touchPos);
            }
        }

        private bool _isMultiTouchStart = false;
        /// <summary>
        /// ��㴥����ʼ
        /// </summary>
        /// <param name="touchPos1"></param>
        /// <param name="touchPos2"></param>
        void MultiTouchStart (Vector2 touchPos1 , Vector2 touchPos2)
        {
            //��ȡ�մ���ʱ�Ĵ���λ�ü�¼
            if ( !_isMultiTouchStart )
            {
                mapInputStatusMachine.CurrentStatus.MultiTouchStart (touchPos1 , touchPos2);
                _isMultiTouchStart = true;
            }
            //���������ƶ�
            else
            {
                if ( _multiTouchPos1 == _multiTouchPos2 )
                {
                    return;
                }
                mapInputStatusMachine.CurrentStatus.MultiTouchMove (touchPos1 , touchPos2);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        void TouchEnd ()
        {
            if ( !_isTouchStart )
            {
                return;
            }
            _isTouchStart = false;
            mapInputStatusMachine.CurrentStatus.TouchEnd ();
        }

        /// <summary>
        /// ��㴥������
        /// </summary>
        void MultiTouchEnd ()
        {
            if ( !_isMultiTouchStart )
            {
                return;
            }
            _isMultiTouchStart = false;
            mapInputStatusMachine.CurrentStatus.MultiTouchEnd ();
        }
    }
}