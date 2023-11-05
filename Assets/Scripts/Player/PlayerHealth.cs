using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        [SerializeField] private float health;

        private float Health
        {
            get => health;
            set => health = value;
        }

        private void Awake()
        {
            Health = maxHealth;
            Debug.Log("Start hp is: " + Health);
        }

        public void Damage(float amount)
        {
            ChangeHealth(-amount);
        }

        public void Heal(float amount)
        {
            ChangeHealth(amount);
        }

        private void ChangeHealth(float amount)
        {
            Health += amount;

            if (Health <= 0)
            {
                Die();
                return;
            }

            if (Health >= maxHealth)
            {
                Health = maxHealth;
            }

            TriggerHealthChange(amount);
        }

        private void Die()
        {
            EventBus.Trigger(PlayerDiedEvent.EventName, new PlayerDiedEvent("Consumed by darkness"));
        }

        private void TriggerHealthChange(float amount)
        {
            EventBus.Trigger(HealthChangedEvent.EventName, new HealthChangedEvent(Health, amount, maxHealth));
        }
    }
}