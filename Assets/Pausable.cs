using UnityEngine;

public class Pausable : MonoBehaviour
{
    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }
}