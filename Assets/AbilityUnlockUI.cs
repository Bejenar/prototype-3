using DefaultNamespace;
using Player.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUnlockUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private TextMeshProUGUI abilityName;
    [SerializeField] private TextMeshProUGUI abilityDesc;
    [SerializeField] private Image abilityIcon;

    private void Awake()
    {
        CustomEventBus.Register<AbilityUnlockedEvent>(AbilityUnlockedEvent.EventName, OnAbilityUnlock);
    }


    private void OnAbilityUnlock(AbilityUnlockedEvent e)
    {
        Debug.Log(panel);
        Time.timeScale = 0;

        var meta = e.abilityMetadata;
        abilityName.text = meta.Name;
        abilityDesc.text = meta.Description;
        abilityIcon.sprite = meta.Icon;
        panel.SetActive(true);
    }
}