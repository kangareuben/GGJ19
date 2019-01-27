using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    [SerializeField]
    private float _minValue;
    [SerializeField]
    private float _maxValue;

    private RectTransform _fillTransform;
    private RectTransform _rectTransform;

    private float _value;

    void Awake()
    {
        _rectTransform = transform as RectTransform;

        _fillTransform = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void SetMinMax(float min, float max)
    {
        _minValue = min;
        _maxValue = max;

        SetValue(_value);
    }

    public void SetValue(float newValue)
    {
        _value = newValue;
        float percentage = Mathf.Clamp01((_value - _minValue) / (_maxValue - _minValue));

        _fillTransform.sizeDelta = new Vector2(0, _rectTransform.sizeDelta.y * percentage);
    }
}
