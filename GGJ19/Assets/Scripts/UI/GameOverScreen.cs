using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void Display()
    {
        gameObject.SetActive(true);
        _scoreText.text = "Score: " + GameObject.FindObjectOfType<PlayerScore>().Score;
    }
}
