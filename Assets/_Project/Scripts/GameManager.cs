using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Lazy Singleton
    private static GameManager _instance = null;

    // Lazy singleton
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject();
                _instance = singletonObject.AddComponent<GameManager>();
                singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
            }

            return _instance;
        }
    }
    #endregion

    [SerializeField] private GameObject _pauseMenu = null;
    [SerializeField] private GameObject _gameOverMenu = null;
    [SerializeField] private Text _scoreText = null;
    [SerializeField] private Text _livesText = null;

    private bool _isGameRunning = false;
    public bool IsGameRunning { get => _isGameRunning; private set => _isGameRunning = value; }
    
    private int _score = 0;
    public int Score { get => _score;  }

    private int _lives = 3;
    private bool _startedGame = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        EventManager.Instance.OnPlayerHit += OnPlayerHit;
        EventManager.Instance.OnAnimalKill += OnAnimalKill;
        EventManager.Instance.OnStartGame += OnStartGame;
        EventManager.Instance.OnPauseGame += OnPauseGame;
        UpdateText();
    }

    private void OnPauseGame(bool paused)
    {
        IsGameRunning = !paused;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _startedGame)
        {
            IsGameRunning = !IsGameRunning;
            _pauseMenu.SetActive(!IsGameRunning);
        }
    }
    private void OnStartGame()
    {
        IsGameRunning = true;
        _startedGame = true;
    }

    private void OnAnimalKill(int points)
    {
        _score+= points;
        UpdateText();
    }

    private void OnPlayerHit(int points)
    {
        _lives -= points;
        if (_lives <= 0)
        {
            _isGameRunning = false;
            _gameOverMenu.SetActive(true);
            _lives = 0; // not showing negative number ;)
        }
        UpdateText();
    }


    private void UpdateText()
    {
        _livesText.text = _lives.ToString();
        _scoreText.text = _score.ToString();
    }

}
