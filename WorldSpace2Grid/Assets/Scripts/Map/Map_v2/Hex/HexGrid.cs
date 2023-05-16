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
					_cells [i] = new HexCell (new HexCoordinates (x , z));
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