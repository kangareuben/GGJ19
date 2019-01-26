using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private Transform _connection;

    private SpriteRenderer _sr;
    private Tracer _tracer;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _tracer = GetComponentInChildren<Tracer>();
    }

    public void ReceiveLink()
    {
        _sr.color = Color.red;
    }
}
