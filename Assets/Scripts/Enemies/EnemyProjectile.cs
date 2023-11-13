using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


public class EnemyProjectile : MonoBehaviour
{
    private PlayerHealth _playerHP;
    private Rigidbody2D _rb;
    [SerializeField] private float damageAmount = 20;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerHP = FindObjectOfType<PlayerHealth>();
    }
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerHP != null)
            {
                _playerHP.Damage(damageAmount);
            }
            Destroy(gameObject);
        }
    }



}
