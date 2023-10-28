namespace Player.Events
{
    public class HealthChangedEvent : PlayerEvent
    {
        public HealthChangedEvent(int currentHealth, int healthChange, int maxHealth)
        {
            CurrentHealth = currentHealth;
            HealthChange = healthChange;
            MaxHealth = maxHealth;
        }


        public const string EventName = "player-health-changed";

        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int HealthChange { get; private set; }
    }
}