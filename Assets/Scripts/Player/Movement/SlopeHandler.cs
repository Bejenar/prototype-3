using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class SlopeHandler : MonoBehaviour
{
    [SerializeField] private Transform _slopeCheckPoint;
    [SerializeField] private Vector2 _slopeCheckSize = new(0.49f, 0.03f);
    [SerializeField] private LayerMask slopeLayer;

    [SerializeField] private PhysicsMaterial2D noFrictionMaterial;
    [SerializeField] private PhysicsMaterial2D fullFrictionMaterial;

    private Rigidbody2D _rb;
    private Collider2D _collider;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Physics2D.OverlapBox(_slopeCheckPoint.position, _slopeCheckSize, 0, slopeLayer))
        {
            SetMaterial(fullFrictionMaterial);
        }
        else
        {
            SetMaterial(noFrictionMaterial);
        }
    }

    void SetMaterial(PhysicsMaterial2D material2D)
    {
        _rb.sharedMaterial = material2D;
        _collider.sharedMaterial = material2D;
    }
}