using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerDamagerListener : MonoBehaviour
    {
        private void Start()
        {
            EventBus.Register<EnteredDarknessZoneEvent>(EnteredDarknessZoneEvent.EventName, DamagePlayer);
        }

        private void DamagePlayer(EnteredDarknessZoneEvent healingEvent)
        {
            Debug.Log("Damaging event");
        }
    }
}