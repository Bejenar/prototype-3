namespace Player.Events
{
    public class PlayerDiedEvent : PlayerEvent
    {
        public PlayerDiedEvent(string deathSource)
        {
            DeathSource = deathSource;
        }

        public const string EventName = "player-died";

        public string DeathSource { get; private set; }
    }
}