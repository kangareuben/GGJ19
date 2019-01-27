using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public bool Stopped { get; set; }

    [SerializeField]
    private Vector3 _velocity;

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
        }
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
}
