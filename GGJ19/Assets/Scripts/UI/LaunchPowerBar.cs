using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPowerBar : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private FillBar _fillBar;

    void Awake()
    {
        _fillBar = GetComponent<FillBar>();
    }

    void Start()
    {
        _fillBar.SetMinMax(_playerInput.LaunchSettings.minLaunchPower, _playerInput.LaunchSettings.maxLaunchPower);
    }

    void Update()
    {
        _fillBar.SetValue(_playerInput.LaunchPower);
    }
}
