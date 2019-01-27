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
        _scoreText.text = "score: " + GameObject.FindObjectOfType<PlayerScore>().Score;
        if(PlayerPrefs.HasKey("high_score"))
        {
            _highScoreText.text = "high score: " + PlayerPrefs.GetInt("high_score");
        }
    }
}
