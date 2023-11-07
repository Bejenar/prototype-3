using System.Collections;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player.Abilities
{
    public class IncreaseLightRadiusAbility : BaseAbility
    {
        [SerializeField] private Light2D playerLight;
        [SerializeField] private float radius;
        [SerializeField] private float tick;
        [SerializeField] private float damage;


        private float _initialRadius;
        private bool _abilityOn;

        private void Start()
        {
            _initialRadius = playerLight.pointLightOuterRadius;
            StartCoroutine(TickAbility());
        }

        private void Update()
        {
            if (!toggled) return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E key down");
                _abilityOn = !_abilityOn;
            }

            if (_abilityOn)
            {
                playerLight.pointLightOuterRadius = radius;
                return;
            }

            playerLight.pointLightOuterRadius = _initialRadius;
        }

        private IEnumerator TickAbility()
        {
            while (true)
            {
                if (_abilityOn)
                {
                    EventBus.Trigger(EnteredDarknessZoneEvent.EventName, new EnteredDarknessZoneEvent(damage));
                }

                yield return new WaitForSeconds(tick);
            }
        }
    }
}