using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public bool Stopped { get; set; }

    [SerializeField]
    private Vector3 _velocity;

    private GameObject _home;

    private void Awake()
    {
        _home = GameObject.FindGameObjectWithTag("Home");
    }

    void FixedUpdate()
    {
        if(!Stopped)
        {
            transform.position += _velocity * Time.fixedDeltaTime;

            if(transform.position.x < -9 || transform.position.x > 9)
            {
                _velocity.x *= -1;
            }
            if(transform.position.y < -5 || transform.position.y > 5)
            {
                _velocity.y *= -1;
            }

            RepelFromHome();
        }
    }

    private void RepelFromHome()
    {
        float distanceFromHome = Vector3.Distance(transform.position, _home.transform.position);
        if(distanceFromHome < 1.5f)
        {
            Vector3 forceDirection = (transform.position - _home.transform.position).normalized / (distanceFromHome * 20);
            _velocity += forceDirection;
        }
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
}
