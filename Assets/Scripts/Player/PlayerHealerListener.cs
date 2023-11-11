using DefaultNamespace;
using Player.Events;
using UnityEngine;

namespace Player
{
    public class PlayerHealerListener : MonoBehaviour
    {
        [SerializeField] private int healAmount;
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            CustomEventBus.Register<EnteredLightZoneEvent>(EnteredLightZoneEvent.EventName, HealPlayer);
        }

        private void HealPlayer(EnteredLightZoneEvent lightEvent)
        {
            _playerHealth.Heal(healAmount);
        }
    }
}