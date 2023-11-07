using Player.Abilities;

namespace Player.Events
{
    public class AbilityUnlockedEvent : PlayerEvent
    {
        public AbilityUnlockedEvent(AbilityMetadata abilityMetadata)
        {
            this.abilityMetadata = abilityMetadata;
        }

        public const string EventName = "ability-unlocked";

        public AbilityMetadata abilityMetadata { get; private set; }
    }
}