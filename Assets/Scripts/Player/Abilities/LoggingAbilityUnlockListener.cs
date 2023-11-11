using DefaultNamespace;
using Player.Events;
using UnityEngine;

namespace Player.Abilities
{
    public class LoggingAbilityUnlockListener : MonoBehaviour
    {
        private void Awake()
        {
            CustomEventBus.Register<AbilityUnlockedEvent>(AbilityUnlockedEvent.EventName, OnAbilityUnlock);
        }

        private void OnAbilityUnlock(AbilityUnlockedEvent e)
        {
            Debug.Log("Unlocked ability " + e.abilityMetadata.Name);
        }
    }
}