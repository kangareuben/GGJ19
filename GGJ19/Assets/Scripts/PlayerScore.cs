using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField]
    private ScoreSettings _scoreSettings;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

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

    private void Update()
    {
        _scoreText.text = "score: " + Score;
    }

    [System.Serializable]
    private struct ScoreSettings
    {
        public int newStarScore;
        public int caughtStarScore;
        public int starMultiplier;
    }
}
