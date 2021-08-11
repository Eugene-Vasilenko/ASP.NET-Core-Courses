using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class EventIds
    {
        public static EventId FirstEventId { get; set; } = new EventId(5000, "FirstEventId");
        public static EventId SecondEventId { get; set; } = new EventId(5001, "SecondEventId");
        public static EventId ThirdEventId { get; set; } = new EventId(5002, "ThirdEventId");
    }
}