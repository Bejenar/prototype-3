using System;
using UnityEngine;

namespace Player.Abilities
{
    public class ReduceLightGunCostAbility : BaseAbility
    {
        [SerializeField] private bool test_enabled;

        private LightGun _lightGun;
        private float initialDamage;

        private void Awake()
        {
            _lightGun = FindObjectOfType<LightGun>();
            initialDamage = _lightGun.DamageToPlayer;
            
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
                _lightGun.DamageToPlayer = 0;
            }
            else
            {
                _lightGun.DamageToPlayer = initialDamage;
            }
        }
    }
}