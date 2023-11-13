using Player;
using UnityEngine;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerHP != null)
            {
                _playerHP.Damage(damageAmount);
            }
        }

        Destroy(gameObject);
    }
}