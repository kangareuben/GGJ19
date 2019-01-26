﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Tracer _tracer;

    void Awake() {
        _tracer = GetComponentInChildren<Tracer>();
    }

    public void FireTracer(Vector3 velocity)
    {
        _tracer.Launch(velocity);
    }
}
