using UnityEngine;
using UnityEngine.Events;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;
    [SerializeField] private bool isLeftSide;

    private Animator _animator;

    private static readonly int LeftSideHit = Animator.StringToHash("LeftSideHit");
    private static readonly int RightSideHit = Animator.StringToHash("RightSideHit");


    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Projectile")) return;
        
        if (isLeftSide)
        {
            Debug.Log("Left Side Trigger inside " + name);
            _animator.SetTrigger(LeftSideHit);
        }
        else
        {
            Debug.Log("Right Side Trigger inside " + name);
            _animator.SetTrigger(RightSideHit);
        }
        
        Destroy(other.gameObject);
    }

    public void OnEventTrigger()
    {
        onTrigger?.Invoke();
    }
}