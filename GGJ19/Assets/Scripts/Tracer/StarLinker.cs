using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLinker : MonoBehaviour
{
    [SerializeField]
    private GameObject _linkPrefab;

    private Tracer _tracer;

    private GameObject _activeLink;

    void Awake()
    {
        _tracer = GetComponent<Tracer>();
    }

    void Update()
    {
        if(_activeLink != null)
        {
            Vector3 diff = _activeLink.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            _activeLink.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);

            ScaleToPoint(transform.position);
        }
    }

    public void CreateActiveLink()
    {
        if(_activeLink != null) { return; }

        _activeLink = Instantiate(_linkPrefab, _tracer.CurrentStar);
    }

    public void EndActiveLink()
    {
        ScaleToPoint(_tracer.CurrentStar.position);
        _activeLink = null;
    }

    private void ScaleToPoint(Vector3 point)
    {
        if(_activeLink != null)
        {
            Vector3 tempScale = _activeLink.transform.localScale;
            tempScale.x = (_activeLink.transform.position - point).magnitude/* * 1.5f*/;
            _activeLink.transform.localScale = tempScale;
        }
    }
}
