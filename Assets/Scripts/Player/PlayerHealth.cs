using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth;

        [SerializeField] private int health;

        private int Health
        {
            get => health;
            set => health = value;
        }

        private void Start()
        {
            Health = maxHealth;
            Debug.Log("Start hp is: " + Health);
        }

        public void Damage(int amount)
        {
            ChangeHealth(-amount);
        }

        public void Heal(int amount)
        {
            ChangeHealth(amount);
        }

        private void ChangeHealth(int amount)
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

            Debug.Log("Current hp is: " + Health);
            // throw changeHealth event ?
        }

        private void Die()
        {
            EventBus.Trigger(PlayerDiedEvent.EventName, new PlayerDiedEvent("Consumed by darkness"));
        }
    }
}