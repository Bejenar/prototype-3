using Player.Events;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbilityUnlockUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private TextMeshProUGUI abilityName;
    [SerializeField] private TextMeshProUGUI abilityDesc;
    [SerializeField] private Image abilityIcon;

    private void Awake()
    {
        EventBus.Register<AbilityUnlockedEvent>(AbilityUnlockedEvent.EventName, OnAbilityUnlock);
    }

    private void OnAbilityUnlock(AbilityUnlockedEvent e)
    {
        Time.timeScale = 0;
        
        var meta = e.abilityMetadata;
        abilityName.text = meta.Name;
        abilityDesc.text = meta.Description;
        abilityIcon.sprite = meta.Icon;
        panel.SetActive(true);
    }
}