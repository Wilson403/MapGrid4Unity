using UnityEngine;

namespace MapGrid4Unity
{
	public struct HexCoordinates
	{
		public int X { get; private set; }
		public int Z { get; private set; }
		public int Y { get { return -X - Z; } } //X+Y+Z=0

		public HexCoordinates (int x , int z)
		{
			X = x;
			Z = z;
		}

		public static Vector3 HexCoordinates2WorldPos (HexCoordinates hexCoordinates)
		{
			return new Vector3 (( hexCoordinates.X + hexCoordinates.Z * 0.5f - hexCoordinates.Z / 2 ) * HexMetrics.innerRadius * 2 , 0 , hexCoordinates.Z * HexMetrics.outerRadius * 1.5f);
		}

		public static HexCoordinates FromOffsetCoordinates (HexCoordinates hexCoordinates)
		{
			return new HexCoordinates (hexCoordinates.X - hexCoordinates.Z / 2 , hexCoordinates.Z);
		}

		public static HexCoordinates FromPostion (Vector3 position)
		{
			float x = position.x / ( HexMetrics.innerRadius * 2f );
			float y = -x;

			//每隔2行向左偏移一个单位
			float offset = position.z / ( HexMetrics.outerRadius * 3f );
			x -= offset;
			y -= offset;

			//坐标是整数，要进行四舍五入
			int iX = Mathf.RoundToInt (x);
			int iY = Mathf.RoundToInt (y);
			int iZ = Mathf.RoundToInt (-x - y);

			//四舍五入可能会有误差，一般在边缘误差最大，抛弃掉误差最大的值，再由另外的2个数重新计算出来
			if ( iX + iY + iZ != 0 )
			{
				float dx = x - iX;
				float dy = y - iY;
				float dz = -x - y - iZ;

				if ( dx > dy && dx > dz )
				{
					iX = -iY - iZ;
				}
				else if ( dy > dx && dy > dz )
				{
					iY = -iX - iZ;
				}
				else if ( dz > dx && dz > dy )
				{
					iZ = -iX - iY;
				}
			}

			//重算后再检查一遍
			if ( iX + iY + iZ != 0 )
			{
				Debug.LogError ($"ERROR:坐标总和不为0");
			}

			return new HexCoordinates (iX , iZ);
		}

		public override string ToString ()
		{
			return $"({X},{Y},{Z})";
		}

		public string ToStringOnSeparateLines ()
		{
			return $"{X}\n{Y}\n{Z}";
		}
	}
}