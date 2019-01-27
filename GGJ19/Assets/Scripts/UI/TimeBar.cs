using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    [SerializeField]
    private Timer _timer;

    private FillBar _fillBar;

    void Awake()
    {
        _fillBar = GetComponent<FillBar>();
    }

    void Start()
    {
        _fillBar.SetMinMax(0, _timer.MaxTime);
    }

    void Update()
    {
        _fillBar.SetValue(_timer.Current);
    }
}
