using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    public void Display()
    {
        gameObject.SetActive(true);
        _scoreText.text = "Score: " + GameObject.FindObjectOfType<PlayerScore>().Score;
        if(PlayerPrefs.HasKey("high_score"))
        {
            _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("high_score");
        }
    }
}
