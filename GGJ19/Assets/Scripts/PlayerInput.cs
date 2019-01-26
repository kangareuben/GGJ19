using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float LaunchPower { get; private set; }
    public Settings LaunchSettings { get { return _launchSettings; } }
    [SerializeField]
    private Settings _launchSettings;

    private Tracer _tracer;
    private Transform _currentTransform;

    void Awake()
    {
        _tracer = GetComponent<Tracer>();
        LaunchPower = _launchSettings.minLaunchPower;
    }

    void Start()
    {
        _currentTransform = GetComponent<Transform>();
        LaunchPower = _launchSettings.minLaunchPower;
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
        LaunchPower += _launchSettings.launchScaleRate * Time.deltaTime;
        LaunchPower = Mathf.Min(LaunchPower, _launchSettings.maxLaunchPower);
    }

    private void Launch()
    {
        Vector3 transformScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = Vector3.Normalize(Input.mousePosition - transformScreenPos);

        _tracer.Launch(direction * LaunchPower);

        LaunchPower = _launchSettings.minLaunchPower;
    }

    [System.Serializable]
    public struct Settings
    {
        public float minLaunchPower;
        public float maxLaunchPower;
        public float launchScaleRate;
    }
}
