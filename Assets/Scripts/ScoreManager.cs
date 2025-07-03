using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    void IncreaseScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
