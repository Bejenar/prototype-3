using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerDamagerListener : MonoBehaviour
    {
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            EventBus.Register<EnteredDarknessZoneEvent>(EnteredDarknessZoneEvent.EventName, DamagePlayer);
            EventBus.Register<PlayerProjectileShotEvent>(PlayerProjectileShotEvent.EventName, DamagePlayer);
        }

        private void DamagePlayer(IDamagingEvent e)
        {
            _playerHealth.Damage(e.damage);
        }
    }
}