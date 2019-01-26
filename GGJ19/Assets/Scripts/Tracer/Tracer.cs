using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public Transform currentStar;

    public Transform CurrentStar { get; set; }
    public bool Landed { get; set; }

    private TracerMotor _motor;
    private StarLinker _linker;

    void Awake()
    {
        CurrentStar = currentStar;

        _motor = GetComponent<TracerMotor>();
        _linker = GetComponent<StarLinker>();
    }

    public void Launch(Vector3 velocity)
    {
        _linker.CreateActiveLink();
        _motor.Launch(velocity);
    }

    public void ChangeStar(GameObject star)
    {
        CurrentStar = star.transform;
        _linker.EndActiveLink();
    }

    public void Land()
    {
        Landed = true;
    }
}
