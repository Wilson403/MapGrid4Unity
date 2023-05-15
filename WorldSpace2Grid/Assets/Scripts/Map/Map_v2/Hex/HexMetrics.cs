using UnityEngine;

namespace MapGrid4Unity
{
	public class HexMetrics
	{
		public const float outerRadius = 10f; //�������Բ�뾶Ϊ10
		public const float innerRadius = outerRadius * 0.866025404f;

		public static Vector3 [] corners = {
			new Vector3(0f, 0f, outerRadius),
			new Vector3(innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(0f, 0f, -outerRadius),
			new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(0f, 0f, outerRadius)};
	}
}