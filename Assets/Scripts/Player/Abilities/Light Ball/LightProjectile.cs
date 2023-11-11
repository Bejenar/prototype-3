using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;
    private Light2D _light2D;

    [SerializeField] private float duration = 3f;

    private AnimationCurve animationCurve;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _light2D = GetComponent<Light2D>();
        _rb.gravityScale = 0;
        _rb.isKinematic = false;

        animationCurve = AnimationCurve.Linear(0f, _light2D.intensity, duration, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("On Collision Enter " + other.gameObject.name);
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
        Destroy(_rb);
        Destroy(_spriteRenderer);
        Destroy(_collider2D);
        StartCoroutine(FadeOutAndDie());
    }

    private IEnumerator FadeOutAndDie()
    {
        var timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            var currentValue = animationCurve.Evaluate(timeElapsed);
            _light2D.intensity = currentValue;
            yield return null;
        }

        Destroy(gameObject);
    }
}