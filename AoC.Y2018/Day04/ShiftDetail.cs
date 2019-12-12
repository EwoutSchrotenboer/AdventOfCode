using AoC.Helpers.Utils;

namespace AoC.Y2018.Days
{
    public class ShiftDetail
    {
        public int Minute { get; set; }
        public GuardStatus Status { get; set; }

        public ShiftDetail(Event e) : this(e.Minute, e.EventType)
        {
        }

        public ShiftDetail(int minute) : this(minute, GuardStatus.Awake)
        {
        }

        public ShiftDetail(int minute, GuardStatus status)
        {
            this.Minute = minute;
            this.Status = status;
        }

        public ShiftDetail(int minute, EventType type)
        {
            this.Minute = minute;
            this.Status = this.GetStatusByEvent(type);
        }

        public void UpdateStatus(EventType type)
        {
            this.Status = this.GetStatusByEvent(type);
        }

        private GuardStatus GetStatusByEvent(EventType type) => (type == EventType.BeginsShift || type == EventType.WakesUp) ? GuardStatus.Awake : GuardStatus.Asleep;
    }
}