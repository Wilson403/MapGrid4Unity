namespace WorldSpace2Grid
{
    public class GameCmd
    {
        [ConsoleCmd ("Test")]
        public static void Test (float v1 , float v2)
        {
            MapMgr.Ins.GeneratedMapItem (new UnityEngine.Vector2 (v1 , v2));
        }

        [ConsoleCmd ("Test2")]
        public static void Test2 ()
        {
            for ( int i = 0 ; i < 10 ; i++ )
            {
                for ( int j = 0 ; j < 10 ; j++ )
                {
                    MapMgr.Ins.GeneratedMapItem (new UnityEngine.Vector2 (i , j));
                }
            }           
        }
    }
}