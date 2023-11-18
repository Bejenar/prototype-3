using DefaultNamespace;
using Player.Events;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthUI : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        CustomEventBus.Register<HealthChangedEvent>(HealthChangedEvent.EventName, OnHealthChanged);
    }

    private void OnHealthChanged(HealthChangedEvent obj)
    {
        _slider.value = obj.CurrentHealth / obj.MaxHealth;
    }
}