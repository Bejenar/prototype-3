using UnityEngine;

public class LightProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("On Collision Enter");
        if (other.gameObject.CompareTag("Mirror"))
        {
            return;
        }

        SelfDestruct();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On trigger enter" + other.name);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}