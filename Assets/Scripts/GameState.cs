using Player.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameState : MonoBehaviour
    {
        private void Start()
        {
            CustomEventBus.Register<PlayerDiedEvent>(PlayerDiedEvent.EventName, OnPlayerDied);
        }

        void OnPlayerDied(PlayerDiedEvent playerDiedEvent)
        {
            Debug.Log("Player died, reason: " + playerDiedEvent.DeathSource);
            LoadScene("SampleScene");
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}