using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float _gameSpeed;

    [SerializeField]
    private Timer _timer;
    [SerializeField]
    private GameOverScreen _gameOverScreen;

    public float GameSpeed
    {
        set
        {
            _gameSpeed = value;
            Time.timeScale = _gameSpeed;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            _timer = GetComponent<Timer>();
            _timer.OnTimeComplete += GameLose;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameSpeed(float speed)
    {
        GameSpeed = speed;
    }

    private void GameLose()
    {
        _gameOverScreen.Display();
    }
}