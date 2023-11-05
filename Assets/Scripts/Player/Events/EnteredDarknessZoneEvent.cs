namespace Player.Events
{
    public class EnteredDarknessZoneEvent : PlayerEvent, IDamagingEvent
    {
        public EnteredDarknessZoneEvent(float damage)
        {
            this.damage = damage;
        }

        public const string EventName = "entered-darkness-zone";

        public float damage { get; }
    }
}