using System;
using System.Collections;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class LightIntensityHandler : MonoBehaviour
    {
        private Light2D _light;
        private float initialIntensity;

        private bool flicker;

        private void Start()
        {
            flicker = false;
            _light = GetComponent<Light2D>();
            initialIntensity = _light.intensity;
            EventBus.Register<HealthChangedEvent>(HealthChangedEvent.EventName, OnHealthChanged);

            StartCoroutine(Flicker());
        }
        
        private IEnumerator Flicker()
        {
            yield return new WaitForSeconds(1f);
            
            while (true)
            {
                if (flicker)
                {
                    var currentIntensity = _light.intensity;
            
                    _light.intensity = 0f;
            
                    yield return new WaitForSeconds(0.1f);
            
                    _light.intensity = currentIntensity;
                }
                
                yield return new WaitForSeconds(1.0f);
            }
        }

        private void OnHealthChanged(HealthChangedEvent healthChangedEvent)
        {
            var currentHealthRatio = (healthChangedEvent.CurrentHealth  / (float) healthChangedEvent.MaxHealth);
            _light.intensity = currentHealthRatio * currentHealthRatio * initialIntensity;


            flicker = currentHealthRatio <= 0.5f;
        }
    }
}