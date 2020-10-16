namespace BattleShip
{
    public class ShipPosition
    {
        public enum AlignmentType
        {
            Vertical = 0,
            Horizontal
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public AlignmentType Align { get; set; }
    }
}
