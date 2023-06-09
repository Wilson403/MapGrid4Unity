using UnityEngine;

namespace MapGrid4Unity
{
	public class HexGrid : IMapGrid
	{
		public int width = 6;
		public int height = 6;
		private readonly HexCell [] _cells;
		public readonly HexMesh hexMesh;


		public HexGrid ()
		{
			_cells = new HexCell [height * width];
			for ( int z = 0, i = 0 ; z < height ; z++ )
			{
				for ( int x = 0 ; x < width ; x++ )
				{
					_cells [i] = new HexCell (new HexCoordinates (x , z));
					_cells [i].Elevation = Random.Range (0 , 10);
#if UNITY_EDITOR
					_cells [i].CreateDebugObj ();
#endif
					i++;
				}
			}

			//创建HexMesh用于绘制六边形
			GameObject hexMeshObj = new GameObject ("hexMesh");
			hexMeshObj.transform.position = Vector3.zero;
			hexMeshObj.AddComponent<MeshRenderer> ().material = Resources.Load<Material> ("materials/hexCell");
			hexMeshObj.AddComponent<MeshFilter> ();
			hexMesh = hexMeshObj.AddComponent<HexMesh> ();

			Refresh ();
		}

		public HexCell GetHexCell (HexCoordinates hexCoordinates)
		{
			int index = hexCoordinates.X + hexCoordinates.Z * width + hexCoordinates.Z / 2;
			if ( index >= _cells.Length )
			{
				return default;
			}
			return _cells [index];
		}

		public void Refresh ()
		{
			hexMesh.Triangulate (_cells);
		}

		/// <summary>
		/// 设置海拔
		/// </summary>
		/// <param name="hexCoordinates"></param>
		/// <param name="elevation"></param>
		public void SetHexCellElevation (HexCoordinates hexCoordinates , int elevation)
		{
			HexCell hexCell = GetHexCell (hexCoordinates);
			if ( hexCell != null )
			{
				hexCell.Elevation = elevation;
				Refresh ();
			}
		}
	}
}