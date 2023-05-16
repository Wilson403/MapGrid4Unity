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

		public static HexCoordinates FromOffsetCoordinates (int x , int z)
		{
			return new HexCoordinates (x - z / 2 , z);
		}

		public override string ToString ()
		{
			return $"{X}\n{Y}\n{Z}";
		}
	}
}