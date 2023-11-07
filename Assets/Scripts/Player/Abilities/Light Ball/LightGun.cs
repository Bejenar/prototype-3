using Player.Abilities;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

public class LightGun : BaseAbility
{
    [SerializeField] private float damageToPlayer;
    [SerializeField] private float shotsPerSecond;
    [SerializeField] private float projectileSpeed;
    [Space] [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private Camera mainCam;
    private float rotZ;

    private Collider2D _playerCollider;
    private float fireRate => 1 / shotsPerSecond;
    private float _fireCooldown;

    public float DamageToPlayer
    {
        get => damageToPlayer;
        set => damageToPlayer = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _playerCollider = transform.parent.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!toggled) return;

        _fireCooldown -= Time.deltaTime;

        CalculateRotation();

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            FireProjectile();
        }
    }

    private bool CanShoot()
    {
        return _fireCooldown <= 0;
    }

    private void CalculateRotation()
    {
        var mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        var rotation = (mousePos - transform.position).normalized;

        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    private void FireProjectile()
    {
        SpawnProjectile();
        _fireCooldown = fireRate;
    }

    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        projectile.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;

        var collider = projectile.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(collider, _playerCollider);

        EventBus.Trigger(PlayerProjectileShotEvent.EventName, new PlayerProjectileShotEvent(damageToPlayer));
    }
}