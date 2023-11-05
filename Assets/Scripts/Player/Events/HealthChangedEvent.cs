namespace Player.Events
{
    public class HealthChangedEvent : PlayerEvent
    {
        public HealthChangedEvent(float currentHealth, float healthChange, float maxHealth)
        {
            CurrentHealth = currentHealth;
            HealthChange = healthChange;
            MaxHealth = maxHealth;
        }


        public const string EventName = "player-health-changed";

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public float HealthChange { get; private set; }
    }
}