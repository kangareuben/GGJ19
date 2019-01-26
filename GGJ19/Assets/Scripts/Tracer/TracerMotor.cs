using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerMotor : MonoBehaviour
{
    [SerializeField]
    private Settings _motorSettings;

    private Tracer _tracer;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    private Vector3 _velocity;

    private bool _isReturning;

    void Awake()
    {
        _tracer = GetComponent<Tracer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        _isReturning = false;
    }

    void FixedUpdate()
    {
        if(!_tracer.Landed)
        {
            _rigidbody.velocity -= new Vector2(Gravity().x, Gravity().y);

            if(_rigidbody.velocity.magnitude <= 0.5)
            {
                _isReturning = true;
            }
        }
    }

    public void Launch(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
        _tracer.Landed = false;
        _isReturning = false;
        _collider.enabled = true;
    }

    public void ChangeStar(GameObject starGO)
    {
        _tracer.ChangeStar(starGO);
        Land();
    }

    private void Land()
    {
        _tracer.Land();
        _collider.enabled = false;
        transform.position = _tracer.CurrentStar.position;
        _rigidbody.velocity = Vector2.zero;
    }

    private Vector3 Gravity()
    {
        Vector3 dir = transform.position - _tracer.CurrentStar.position;

        return dir.normalized * _motorSettings.gravity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == _tracer.CurrentStar.gameObject)
        {
            if(_isReturning)
            {
                Land();
            }
        }
        else
        {
            ChangeStar(collider.gameObject);
        }
    }

    [System.Serializable]
    private struct Settings
    {
        public float gravity;
        public float gravityScaling;
    }
}
