using Player.Abilities;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] private BaseAbility abilityToUnlock;

    private void OnTriggerEnter2D(Collider2D other)
    {
        abilityToUnlock.toggled = true;
        EventBus.Trigger(AbilityUnlockedEvent.EventName, new AbilityUnlockedEvent(abilityToUnlock.AbilityMetadata));
        Destroy(gameObject);
    }
}