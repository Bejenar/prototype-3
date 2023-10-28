using Player.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameState : MonoBehaviour
    {
        private void Start()
        {
            EventBus.Register<PlayerDiedEvent>(PlayerDiedEvent.EventName, OnPlayerDied);
        }

        void OnPlayerDied(PlayerDiedEvent playerDiedEvent)
        {
            Debug.Log("Player died, reason: " + playerDiedEvent.DeathSource);
        }
    }
}