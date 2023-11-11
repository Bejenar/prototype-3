using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CustomEventBus
    {
        public static void Register<TArgs>(EventHook hook, Action<TArgs> handler)
        {
            EventBus.Register(hook, handler);
            SceneManager.sceneUnloaded += _ => EventBus.Unregister(hook, handler);
        }
    }
}