using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private Transform _connection;

    private SpriteRenderer _sr;
    private Collider2D _collider;

    private bool _collecting;
    private Vector3 _collectionPoint;
    private Vector3 _collectionDirection;

    void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(_collecting)
        {
            transform.position += _collectionDirection * Time.deltaTime;

            if(Vector3.Distance(transform.position, _collectionPoint) <= 0.5)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ReceiveLink()
    {
        _sr.color = Color.red;
    }

    public void Collect(Transform collectionPoint)
    {
        _collecting = true;
        _collider.enabled = false;

        StartCoroutine(MoveToCollection(collectionPoint));
    }

    private IEnumerator MoveToCollection(Transform collectionPoint)
    {
        _collectionPoint = collectionPoint.position;
        _collectionDirection = (_collectionPoint - transform.position).normalized;

        while(Vector3.Distance(transform.position, _collectionPoint) > 0.1)
        {
            transform.position += _collectionDirection * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
