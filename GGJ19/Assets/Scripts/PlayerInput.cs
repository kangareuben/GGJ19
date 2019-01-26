using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private LaunchSettings _launchSettings;

    private Tracer _tracer;
    private Transform _currentTransform;

    private float _launchPower;

    void Awake()
    {
        _tracer = GetComponent<Tracer>();
        _launchPower = _launchSettings.minLaunchPower;
    }

    void Start()
    {
        _currentTransform = GetComponent<Transform>();
        _launchPower = _launchSettings.minLaunchPower;
    }

    void Update()
    {
        RotateTowardMouse();

        if(_tracer.Landed)
        {
            if(Input.GetMouseButton(0))
            {
                ChargeLaunch();
            }
            if(Input.GetMouseButtonUp(0))
            {
                Launch();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _tracer.CollectStars();
            }
        }
    }

    private void RotateTowardMouse()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void ChargeLaunch()
    {
        _launchPower += _launchSettings.launchScaleRate * Time.deltaTime;
        _launchPower = Mathf.Min(_launchPower, _launchSettings.maxLaunchPower);
    }

    private void Launch()
    {
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
