using UnityEngine;

namespace MapGrid4Unity
{
    public class HexCell
    {
        public readonly Vector3 pos;

        public HexCell (Vector3 pos)
        {
            this.pos = pos;
        }

        /// <summary>
        /// ����ʵ�壬�������չʾ��Ϣ
        /// </summary>
        public void CreateDebugObj ()
        {
            var obj = GameObject.Instantiate (Resources.Load<GameObject> ("HexCell"));
            obj.transform.SetParent (MapRuntime.Ins.content , false);
            obj.transform.localPosition = pos;
            obj.GetComponentInChildren<UnityEngine.UI.Text> ().text = $"({pos.x:F1},{pos.z:F1})";
        }
    }
}