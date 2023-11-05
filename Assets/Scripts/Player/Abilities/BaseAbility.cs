using UnityEngine;

namespace Player.Abilities
{
    public abstract class BaseAbility : MonoBehaviour
    {
        private bool _enabled;

        protected bool toggled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                OnToggle(value);
            }
        }

        protected virtual void OnToggle(bool toggle) {}
    }
}