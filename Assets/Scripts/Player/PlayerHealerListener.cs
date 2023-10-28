using Player.Events;
using Unity.VisualScripting;
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
            EventBus.Register<EnteredLightZoneEvent>(EnteredLightZoneEvent.EventName, HealPlayer);
        }

        private void HealPlayer(EnteredLightZoneEvent lightEvent)
        {
            _playerHealth.Heal(healAmount);
        }
    }
}