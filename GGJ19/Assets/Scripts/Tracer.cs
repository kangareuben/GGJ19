using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public Transform currentNode;

    public Transform CurrentNode { get; set; }

    void Awake()
    {
        CurrentNode = currentNode;
    }
}
