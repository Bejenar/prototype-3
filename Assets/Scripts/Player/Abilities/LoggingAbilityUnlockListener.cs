using System;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.Abilities
{
    public class LoggingAbilityUnlockListener : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Register<AbilityUnlockedEvent>(AbilityUnlockedEvent.EventName, OnAbilityUnlock);
        }

        private void OnAbilityUnlock(AbilityUnlockedEvent e)
        {
            Debug.Log("Unlocked ability " + e.abilityMetadata.Name);
        }
    }
}