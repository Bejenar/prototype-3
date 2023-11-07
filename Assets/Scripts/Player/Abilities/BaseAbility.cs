using UnityEngine;

namespace Player.Abilities
{
    public abstract class BaseAbility : MonoBehaviour
    {
        [SerializeField] private AbilityMetadata _abilityMetadata;
        public AbilityMetadata AbilityMetadata => _abilityMetadata;

        private bool _enabled;

        public bool toggled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                OnToggle(value);
            }
        }

        protected virtual void OnToggle(bool toggle)
        {
        }
    }
}