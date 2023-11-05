using System;
using System.Collections;
using Player.Abilities;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

public class InsideLightsourceBehavior : MonoBehaviour
{
    [SerializeField] private LayerMask healingLightMask;
    [SerializeField] private LayerMask ordinaryLightMask;
    [SerializeField] float tickTimer;

    [SerializeField] public float darknessDamagePerTick; 

    private bool isInsideHealingZone;
    private bool isInsideLightZone;

    void Start()
    {
        isInsideHealingZone = false;
        StartCoroutine(TickZoneCheck());
    }

    private IEnumerator TickZoneCheck()
    {
        while (true)
        {
            if (isInsideHealingZone)
            {
                EventBus.Trigger(EnteredLightZoneEvent.EventName, new EnteredLightZoneEvent(true));
            }
            else if (!isInsideLightZone)
            {
                EventBus.Trigger(EnteredDarknessZoneEvent.EventName, new EnteredDarknessZoneEvent(darknessDamagePerTick));
            }

            yield return new WaitForSeconds(tickTimer);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ordinaryLightMask.Includes(other))
        {
            isInsideLightZone = true;
        }

        if (healingLightMask.Includes(other))
        {
            isInsideHealingZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (ordinaryLightMask.Includes(other))
        {
            isInsideLightZone = false;
        }

        if (healingLightMask.Includes(other))
        {
            isInsideHealingZone = false;
        }
    }
}