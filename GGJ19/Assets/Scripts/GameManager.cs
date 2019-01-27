using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

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
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        
    }
}