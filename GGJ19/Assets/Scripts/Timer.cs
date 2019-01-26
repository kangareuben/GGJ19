using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Current { get; private set; }
    public float MaxTime { get { return _maxTime; } }

    public delegate void del_OnTimeComplete();
    public del_OnTimeComplete OnTimeComplete;

    [SerializeField]
    private float _maxTime;

    private bool _stopped;

    void Start()
    {
        Current = _maxTime;
    }

    void Update()
    {
        if(_stopped) { return; }

        Current -= Time.deltaTime;

        if(Current <= 0)
        {
            Current = 0;
            _stopped = true;
            
            if(OnTimeComplete != null) { OnTimeComplete(); }
        }
        Current = Mathf.Max(0, Current);
    }

    public void AddTime(float extraTime)
    {
        Current += extraTime;
        Current = Mathf.Min(_maxTime, Current);
    }
}
