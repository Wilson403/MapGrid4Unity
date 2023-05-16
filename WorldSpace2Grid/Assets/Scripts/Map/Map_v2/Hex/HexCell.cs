using UnityEngine;

namespace MapGrid4Unity
{
    public class HexCell
    {
        public readonly Vector3 worldPos;
        public readonly HexCoordinates hexCoordinates;

        public HexCell (HexCoordinates hexCoordinates)
        {
            this.worldPos = new Vector3 (( hexCoordinates.X + hexCoordinates.Z * 0.5f - hexCoordinates.Z / 2 ) * HexMetrics.innerRadius * 2 , 0 , hexCoordinates.Z * HexMetrics.outerRadius * 1.5f);
            this.hexCoordinates = HexCoordinates.FromOffsetCoordinates (hexCoordinates.X , hexCoordinates.Z);
        }

        /// <summary>
        /// 生成实体，方便调试展示信息
        /// </summary>
        public void CreateDebugObj ()
        {
            var obj = GameObject.Instantiate (Resources.Load<GameObject> ("HexCell"));
            obj.transform.SetParent (MapRuntime.Ins.content , false);
            obj.transform.localPosition = worldPos;
            obj.GetComponentInChildren<UnityEngine.UI.Text> ().text = hexCoordinates.ToString ();
        }
    }
}