using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    private PlayerScore _score;
    private Timer _timer;

    private StarFactory _starFactory;
    private List<Star> _starCollection;

    private int _totalCollected;

    void Awake()
    {
        _score = GetComponent<PlayerScore>();
        _timer = GameObject.FindObjectOfType<Timer>();
        _starFactory = GameObject.FindObjectOfType<StarFactory>();
        _starCollection = new List<Star>();

        _totalCollected = 0;
    }

    public void AddStar(Star newStar)
    {
        if(!_starCollection.Contains(newStar))
        {
            _starCollection.Add(newStar);
        }

        AudioManager._instance.PlaySound(Mathf.Min(_starCollection.Count, 7) + 3);
    }

    public void Clear()
    {
        _starCollection.Clear();
    }

    public void CollectStars()
    {
        for(int i = 0; i < _starCollection.Count; i++)
        {
            _starCollection[i].Collect(transform);
        }

        _score.AddStars(_starCollection);
        _timer.AddTime(_starCollection.Count + 2);

        _totalCollected += _starCollection.Count;

        if(_totalCollected >= _starFactory.SpawnSettings.startingSpawn)
        {
            GameManager._instance.GameOver();
        }
        
        Clear();
    }
}
