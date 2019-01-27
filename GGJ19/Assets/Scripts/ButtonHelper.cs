using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField]
    private Slider _gameSpeedSlider;
    [SerializeField]
    private TextMeshProUGUI _gameSpeedLabel;

    public void SetGameSpeed()
    {
        GameManager._instance.SetGameSpeed(_gameSpeedSlider.value);
        _gameSpeedLabel.text = "Game Speed: " + _gameSpeedSlider.value.ToString("F1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToggleMute()
    {
        AudioManager._instance.ToggleMute();
    }

    public void PlaySound(int index)
    {
        AudioManager._instance.PlaySound(index);
    }
}
