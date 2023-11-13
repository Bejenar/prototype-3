using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Spike : MonoBehaviour
{
    public float damageAmount = 9999;
    private PlayerHealth _playerHP;
    
    void Start()
    {
        _playerHP = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerHP.Health > 0)
            {
                _playerHP.Damage(damageAmount);
                //play sound
            }

        }
    }

}
