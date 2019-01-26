using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Tracer _tracer;
    [SerializeField]
    private LaunchSettings _launchSettings;

    private Transform _currentTransform;

    private float _launchPower;

    // Start is called before the first frame update
    void Start()
    {
        _launchPower = _launchSettings.minLaunchPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !_tracer.Active)
        {
            ChargeLaunch();
        }
        if(Input.GetMouseButtonUp(0))
        {
            FireTrace();
        }
    }

    private void ChargeLaunch()
    {
        _launchPower += _launchSettings.launchScaleRate * Time.deltaTime;
        _launchPower = Mathf.Min(_launchPower, _launchSettings.maxLaunchPower);
    }

    private void FireTrace()
    {
        Debug.Log("Firing with power: " + _launchPower);
        Vector3 transformScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = Vector3.Normalize(Input.mousePosition - transformScreenPos);

        _tracer.Launch(direction * _launchPower);

        _launchPower = _launchSettings.minLaunchPower;
    }

    [System.Serializable]
    private struct LaunchSettings
    {
        public float minLaunchPower;
        public float maxLaunchPower;
        public float launchScaleRate;
    }
}
