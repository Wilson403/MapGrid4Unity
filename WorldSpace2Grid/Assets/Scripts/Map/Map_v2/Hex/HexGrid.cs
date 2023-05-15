using UnityEngine;

namespace MapGrid4Unity
{
	public class HexGrid : IMapGrid
	{
		public int width = 6;
		public int height = 6;
		private readonly HexCell [] _cells;

		public HexGrid ()
		{
			_cells = new HexCell [height * width];
			for ( int z = 0, i = 0 ; z < height ; z++ )
			{
				for ( int x = 0 ; x < width ; x++ )
				{
					Vector3 position = new Vector3 (( x + z * 0.5f - z / 2 ) * HexMetrics.innerRadius * 2 , 0 , z * HexMetrics.outerRadius * 1.5f);
					_cells [i] = new HexCell (position);
#if UNITY_EDITOR
					_cells [i].CreateDebugObj ();
#endif
					i++;
				}
			}
			MapRuntime.Ins.hexMesh.Triangulate (_cells);
		}
	}
}