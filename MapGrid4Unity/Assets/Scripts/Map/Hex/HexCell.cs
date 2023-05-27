using UnityEngine;

namespace MapGrid4Unity
{
    public class HexCell
    {
        public Vector3 worldPos;
        public readonly HexCoordinates hexCoordinates;
        public Color color;

        private int _elevation;
        public int Elevation
        {
            get
            {
                return _elevation;
            }
            set
            {
                worldPos.y += value;
            }
        }

        public HexCell (HexCoordinates hexCoordinates)
        {
            color = new Color (1 , 1 , 1 , 1);
            worldPos = HexCoordinates.HexCoordinates2WorldPos (hexCoordinates);
            this.hexCoordinates = HexCoordinates.FromOffsetCoordinates (hexCoordinates);
        }

        /// <summary>
        /// 生成实体，方便调试展示信息
        /// </summary>
        public void CreateDebugObj ()
        {
            var obj = GameObject.Instantiate (Resources.Load<GameObject> ("HexCell"));
            obj.transform.SetParent (null , false);
            obj.transform.localPosition = worldPos;
            obj.GetComponentInChildren<UnityEngine.UI.Text> ().text = hexCoordinates.ToStringOnSeparateLines ();
        }
    }
}