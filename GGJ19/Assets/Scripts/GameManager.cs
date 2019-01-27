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
    [SerializeField]
    private PlayerScore _score;

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

            _timer.OnTimeComplete += GameOver;
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

    public void GameOver()
    {
        SaveHighScore();

        _gameOverScreen = GameObject.FindGameObjectWithTag("Canvas").transform.Find("GameOverPanel").gameObject.GetComponent<GameOverScreen>();
        _gameOverScreen.Display();
    }

    public void MainMenu()
    {

    }

    private void SaveHighScore()
    {
        int score = GameObject.FindObjectOfType<PlayerScore>().Score;

        if(!PlayerPrefs.HasKey("high_score") || score > PlayerPrefs.GetInt("high_score"))
        {
            PlayerPrefs.SetInt("high_score", score);
        }
    }
}