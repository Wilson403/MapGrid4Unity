using UnityEngine;

namespace MapGrid4Unity
{
    public class HexCell
    {
        public readonly Vector3 worldPos;
        public readonly HexCoordinates hexCoordinates;
        public Color color;

        public HexCell (HexCoordinates hexCoordinates)
        {
            color = new Color (1 , 1 , 1 , 1);
            worldPos = HexCoordinates.HexCoordinates2WorldPos (hexCoordinates);
            this.hexCoordinates = HexCoordinates.FromOffsetCoordinates (hexCoordinates);
        }

        /// <summary>
        /// ����ʵ�壬�������չʾ��Ϣ
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