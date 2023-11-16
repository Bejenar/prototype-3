using Player;
using Player.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;

        private PlayerHealth _playerHealth;
        
        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            CustomEventBus.Register<PlayerDiedEvent>(PlayerDiedEvent.EventName, OnPlayerDied);
        }

        void OnPlayerDied(PlayerDiedEvent playerDiedEvent)
        {
            Debug.Log("Player died, reason: " + playerDiedEvent.DeathSource);
            GameObject.Find("Player").transform.position = spawnPoint.position;
            _playerHealth.Heal(100f);
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}