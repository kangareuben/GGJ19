using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField]
    private ScoreSettings _scoreSettings;

    public void AddStars(List<Star> stars)
    {
        int newScore = 0;

        HashSet<Star> collected = new HashSet<Star>();

        for(int i = 0; i < stars.Count; i++)
        {
            if(collected.Contains(stars[i]))
            {
                newScore += _scoreSettings.caughtStarScore;
            }
            else
            {
                newScore += _scoreSettings.newStarScore;

                collected.Add(stars[i]);
            }
        }

        Score += newScore * collected.Count;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,200,100), "Score: " + Score);
    }

    [System.Serializable]
    private struct ScoreSettings
    {
        public int newStarScore;
        public int caughtStarScore;
        public int starMultiplier;
    }
}
