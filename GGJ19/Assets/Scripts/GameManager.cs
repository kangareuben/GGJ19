using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float _gameSpeed;

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
}