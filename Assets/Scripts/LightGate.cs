using Player;
using UnityEngine;

public class LightGate : MonoBehaviour
{
    [SerializeField] private float LPCost;

    private bool canActivate;
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanOpenGate())
        {
            _playerHealth.Damage(LPCost);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        canActivate = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        canActivate = false;
    }

    private bool CanOpenGate()
    {
        return (_playerHealth.Health > LPCost) && canActivate;
    }
}