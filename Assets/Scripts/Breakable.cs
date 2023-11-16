using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    [SerializeField] private UnityEvent onBreak;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Projectile")) return;
        
        onBreak?.Invoke();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
