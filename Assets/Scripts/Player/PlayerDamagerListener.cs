using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerDamagerListener : MonoBehaviour
    {
        [SerializeField] private int damage;
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            EventBus.Register<EnteredDarknessZoneEvent>(EnteredDarknessZoneEvent.EventName, DamagePlayer);
        }

        private void DamagePlayer(EnteredDarknessZoneEvent healingEvent)
        {
            _playerHealth.Damage(damage);
        }
    }
}