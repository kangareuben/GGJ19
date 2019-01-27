using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public Transform CurrentStar { get; set; }
    public bool Landed { get; set; }

    private TracerMotor _motor;
    private StarLinker _linker;
    private StarCollection _collectedStars;

    void Awake()
    {
        CurrentStar = transform.parent;

        _motor = GetComponent<TracerMotor>();
        _linker = GetComponent<StarLinker>();
        _collectedStars = GameObject.FindObjectOfType<StarCollection>();
    }

    public void Launch(Vector3 velocity)
    {
        _linker.CreateActiveLink();
        _motor.Launch(velocity);
    }

    public void Land(GameObject starGO)
    {
        Landed = true;

        StarMovement prevStarMovement = CurrentStar.GetComponent<StarMovement>();
        if(prevStarMovement != null)
        {
            prevStarMovement.Stopped = false;
        }

        CurrentStar = starGO.transform;
        transform.SetParent(CurrentStar);
        transform.localPosition = Vector3.zero;
        Star star = CurrentStar.GetComponent<Star>();

        if(star != null)
        {
            star.ReceiveLink();
            _collectedStars.AddStar(star);
            star.GetComponent<StarMovement>().Stopped = true;
        }

        _linker.EndActiveLink();
    }

    public void CollectStars()
    {
        Land(_collectedStars.gameObject);
        _collectedStars.CollectStars();
    }
}
