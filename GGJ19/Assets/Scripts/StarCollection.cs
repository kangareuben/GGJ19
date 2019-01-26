﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    private PlayerScore _score;

    private List<Star> _starCollection;

    void Awake()
    {
        _score = GetComponent<PlayerScore>();
        _starCollection = new List<Star>();
    }

    public void AddStar(Star newStar)
    {
        _starCollection.Add(newStar);
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
        
        Clear();
    }
}