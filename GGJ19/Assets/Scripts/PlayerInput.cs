using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject _traceGO;
    [SerializeField]
    private LaunchSettings _launchSettings;

    private Transform _currentTransform;

    private float _launchPower;

    // Start is called before the first frame update
    void Start()
    {
        _launchPower = _launchSettings.baseLaunchPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FireTrace();
        }
    }

    private void FireTrace()
    {
        Vector3 transformScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = Vector3.Normalize(Input.mousePosition - transformScreenPos);

        Tracer trace = Instantiate(_traceGO).GetComponent<Tracer>();
        trace.Launch(direction * _launchPower);
    }

    [System.Serializable]
    private struct LaunchSettings
    {
        public float baseLaunchPower;
        public float maxLaunchPower;
        public float launchScaleRate;
    }
}
