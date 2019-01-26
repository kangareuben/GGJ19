using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public bool Active { get; private set; }

    [SerializeField]
    private float _range = 3f;

    private float _currentRange;
    private Vector3 _velocity = Vector3.zero;

    private float _activeTime = 0;
    private float _launchStrength;
    private Vector3 _targetPosition;

    private bool _isExtending;

    void Awake()
    {
        _currentRange = 0;
    }

    void FixedUpdate()
    {
        if(Active)
        {
            if(_isExtending)
            {
                transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, 0.3f);
                if(Mathf.Abs(transform.position.magnitude - _targetPosition.magnitude) <= 0.01f)
                {
                    _isExtending = false;
                }
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, Vector3.zero, ref _velocity, 0.3f);

                if(transform.position.magnitude <= 0.01f)
                {
                    transform.position = Vector3.zero;
                    Active = false;
                }
            }
        }
    }



    public void Launch(Vector3 velocity)
    {
        transform.position = Vector3.zero;
        _velocity = velocity;
        _launchStrength = velocity.magnitude;
        _targetPosition = _velocity.normalized * _range;
        _activeTime = 0;
        _isExtending = true;
        Active = true;
    }
}
