using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField]
    private Slider _gameSpeedSlider;
    [SerializeField]
    private TextMeshProUGUI _gameSpeedLabel;

    public void SetGameSpeed()
    {
        GameManager.instance.SetGameSpeed(_gameSpeedSlider.value);
        _gameSpeedLabel.text = "Game Speed: " + _gameSpeedSlider.value.ToString("F1");
    }
}
