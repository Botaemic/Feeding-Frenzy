using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Lazy Singelton
    private static EventManager _instance = null;

    // Lazy singleton
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject();
                _instance = singletonObject.AddComponent<EventManager>();
                singletonObject.name = typeof(EventManager).ToString() + " (Singleton)";
            }

            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }

    public UnityAction OnPlayerDead;
    public UnityAction<int> OnAnimalKill;
    public UnityAction<int> OnPlayerHit;
    public UnityAction<int> OnPointCollected;
    public UnityAction OnStartGame;
    public UnityAction OnBallHitGround;
    public UnityAction<bool> OnPauseGame;
}
