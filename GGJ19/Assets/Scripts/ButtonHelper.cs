using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField]
    private Slider gameSpeedSlider;
    [SerializeField]
    private TextMeshProUGUI gameSpeedLabel;

    public void SetGameSpeed()
    {
        GameManager.instance.SetGameSpeed(gameSpeedSlider.value);
        gameSpeedLabel.text = "Game Speed: " + gameSpeedSlider.value.ToString("F1");
    }
}
