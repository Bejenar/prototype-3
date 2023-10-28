namespace Player.Events
{
    public class EnteredLightZoneEvent : PlayerEvent
    {
        public EnteredLightZoneEvent(bool isHealingLight)
        {
            IsHealingLight = isHealingLight;
        }

        public const string EventName = "entered-light-zone";

        public bool IsHealingLight { get; protected set; }
    }
}