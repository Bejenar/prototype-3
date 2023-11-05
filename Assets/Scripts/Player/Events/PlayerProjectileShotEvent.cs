namespace Player.Events
{
    public class PlayerProjectileShotEvent : PlayerEvent, IDamagingEvent
    {
        public PlayerProjectileShotEvent(float damage)
        {
            this.damage = damage;
        }

        public const string EventName = "player-projectile-shot";

        public float damage { get; }
    }
}