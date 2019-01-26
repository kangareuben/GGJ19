using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 2f;

    private Vector3 _velocity = Vector3.zero;

    void FixedUpdate()
    {
        transform.position += _velocity;
    }

    public void Launch(Vector3 velocity)
    {
        _velocity = velocity;
        Destroy(gameObject, _lifetime);
    }
}
