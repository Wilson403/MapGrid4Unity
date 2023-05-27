using UnityEngine;

namespace MapGrid4Unity
{
	public class HexMetrics
	{
		public const float outerRadius = 10f; //假设外接圆半径为10
		public const float innerRadius = outerRadius * 0.866025404f;

		/// <summary>
		/// Hex各顶点的位置
		/// 尖头朝上，顺时针方向
		/// </summary>
		public static Vector3 [] corners = {
			new Vector3(0f, 0f, outerRadius),
			new Vector3(innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(0f, 0f, -outerRadius),
			new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(0f, 0f, outerRadius)};

		/// <summary>
		/// 将六边形坐标转化为世界位置的矩阵
		/// </summary>
		public static Matrix4x4 hexCoords2WorldPosMatrix = new Matrix4x4 (
			new Vector4 (innerRadius * 2 , 0 , 0 , 0) ,
			new Vector4 (0 , 0 , 0 , 0) ,
			new Vector4 (0 , 0 , outerRadius * 1.5f , 0) ,
			new Vector4 (0 , 0 , 0 , 1));
	}
}