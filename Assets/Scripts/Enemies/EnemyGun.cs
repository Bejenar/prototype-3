using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private float _fireCooldown;
    private Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 5f;

    private bool _playerInSight;

    public bool PlayerInSight => _playerInSight;

    private float fireRate => 1 / shotsPerSecond;
    [SerializeField] private float shotsPerSecond;

    private Collider2D _enemyCollider;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        _enemyCollider = transform.parent.GetComponent<Collider2D>();
        firePoint = GetComponent<Transform>();
    }


    void Update()
    {
        _fireCooldown -= Time.deltaTime;

        AttemptShooting();
    }

    public void AttemptShooting()
    {
        if (_playerInSight && CanShoot())
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            FireProjectile(direction, angle);
        }
    }

    private void FireProjectile(Vector2 direction, float angle)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
        rb.gravityScale = 0;
        rb.isKinematic = false;

        _fireCooldown = fireRate;
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectilePrefab.");
        }
        
        var collider = projectile.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(collider, _enemyCollider);
    }

    private bool CanShoot()
    {
        return _fireCooldown <= 0;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in range of attack");
            _playerInSight = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is out of range");
            _playerInSight = false;
        }
    }
}