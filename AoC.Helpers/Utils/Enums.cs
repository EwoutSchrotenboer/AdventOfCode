namespace AoC.Helpers.Utils
{
    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    public enum EventType
    {
        BeginsShift,
        FallsAsleep,
        WakesUp
    }

    public enum GuardStatus
    {
        Awake,
        Asleep,
        NotHere
    }

    public enum Part
    {
        One = 1,
        Two = 2
    }

    public enum Spell
    {
        MagicMissile,
        Drain,
        Shield,
        Poison,
        Recharge
    }

    public enum StepStatus
    {
        NotReady,
        Ready,
        InProgress,
        Done
    }

    public enum Switch
    {
        On,
        Off,
        Toggle
    }

    public enum TileType
    {
        Empty,
        Wall,
        Block,
        Paddle,
        Ball,
        Score
    }

    public enum Turn
    {
        Left,
        Right
    }
}
