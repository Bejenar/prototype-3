using UnityEngine;

public class LeverController : MonoBehaviour
{
    private LeverTrigger _leftTrigger;
    private LeverTrigger _rightTrigger;

    private Animator _animator;
    
    private static readonly int LeftSideHit = Animator.StringToHash("LeftSideHit");
    private static readonly int RightSideHit = Animator.StringToHash("RightSideHit");

    private void Awake()
    {
        var leverHandle = transform.Find("Rotation Point").Find("Lever Handle");
        _leftTrigger = leverHandle.Find("Left Side").GetComponent<LeverTrigger>();
        _rightTrigger = leverHandle.Find("Right Side").GetComponent<LeverTrigger>();

        _animator = GetComponent<Animator>();
    }

    public void TriggerLeft()
    {
        _leftTrigger.OnEventTrigger();
        _animator.ResetTrigger(RightSideHit);
    }

    public void TriggerRight()
    {
        _rightTrigger.OnEventTrigger();
        _animator.ResetTrigger(LeftSideHit);
    }
}