using UnityEngine;

namespace WorldSpace2Grid
{
    public partial class MapMgr : SafeSingleton<MapMgr>
    {
        public readonly MapInputStatusMachine mapInputStatusMachine = new MapInputStatusMachine ();
        private Vector2 _touchPos1;
        private Vector2 _touchPos2;

        void OnCheckInput ()
        {
            if ( Input.GetMouseButton (0) )
            {
                //�����޷�������ϵͳ�£�ʹ��LeftAlt��ģ���ָ����
                if ( Input.touchCount == 0 )
                {
                    if ( Input.GetKey (KeyCode.LeftAlt) )
                    {
                        _touchPos1 = new Vector2 (Input.mousePosition.x , Input.mousePosition.y);
                        _touchPos2 = new Vector2 (-Input.mousePosition.x , -Input.mousePosition.y);
                        MultiTouchStart (_touchPos1 , _touchPos2);
                        return;
                    }
                }

                //���Դ�����ϵͳ����
                else
                {
                    if ( Input.touchCount > 1 )
                    {
                        _touchPos1 = Input.GetTouch (0).position;
                        _touchPos2 = Input.GetTouch (1).position;
                        MultiTouchStart (_touchPos1 , _touchPos2);
                        return;
                    }
                }
            }

            MultiTouchEnd ();
        }

        private bool _isMultiTouchStart = false;
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
                if ( _touchPos1 == _touchPos2 ) 
                {
                    return;
                }
                mapInputStatusMachine.CurrentStatus.MultiTouchMove (touchPos1 , touchPos2);
            }
        }

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