namespace TakeArms.GameData
{
    public class TileData
    {
        public enum TileState
        {
            Empty,
            Occupied,
            WeakCover,
            SolidCover
        }

        public TileState currentState;
    }
}
