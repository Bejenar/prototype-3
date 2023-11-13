using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _lives = 3;
    public float EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    //private bool _playerInSight = false;


    //public bool PlayerInSight
    //{
    //    get => _playerInSight;
    //    set => _playerInSight = value;
    //}
    //private void Awake()
    //{
    //    _playerInSight = GetComponent<EnemyProjectile>();
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player is in range of attack");
    //        _playerInSight = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player is out of range");
    //        _playerInSight = false;
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Projectile(Clone)")
        {
            EnemyLives -= 1; 
        }
    }

    

}
