using DefaultNamespace;
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
            CustomEventBus.Register<EnteredDarknessZoneEvent>(EnteredDarknessZoneEvent.EventName, DamagePlayer);
            CustomEventBus.Register<PlayerProjectileShotEvent>(PlayerProjectileShotEvent.EventName, DamagePlayer);
        }

        private void DamagePlayer(IDamagingEvent e)
        {
            _playerHealth.Damage(e.damage);
        }
    }
}