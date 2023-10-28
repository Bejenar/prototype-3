using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerHealerListener : MonoBehaviour
    {
        private void Start()
        {
            EventBus.Register<EnteredLightZoneEvent>(EnteredLightZoneEvent.EventName, HealPlayer);
        }

        private void HealPlayer(EnteredLightZoneEvent lightEvent)
        {
            Debug.Log("Healing event");
        }
    }
}