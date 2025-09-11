using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text scoreField;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreField.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreField.text = $"Score: {score}";
    }
}
