using System;
using UnityEngine;

namespace Player.Abilities
{
    public class ModifyDarknessDamageAbility : BaseAbility
    {
        [SerializeField] private float multiplier;

        private InsideLightsourceBehavior _insideLightsourceBehavior;

        [SerializeField] private bool test_enabled;

        private void Awake()
        {
            _insideLightsourceBehavior = FindObjectOfType<InsideLightsourceBehavior>();

            if (toggled)
            {
                OnToggle(toggled);
            }
        }

        private void Update()
        {
            toggled = test_enabled;
        }


        protected override void OnToggle(bool toggle)
        {
            if (toggle)
            {
                _insideLightsourceBehavior.darknessDamagePerTick *= multiplier;
            }
            else
            {
                _insideLightsourceBehavior.darknessDamagePerTick /= multiplier;
            }
        }
    }
}