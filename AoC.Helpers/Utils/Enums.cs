using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Helpers.Utils
{
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

    public enum StepStatus
    {
        NotReady,
        Ready,
        InProgress,
        Done
    }

    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    public enum Turn
    {
        Left,
        Right
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
}
