using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
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
}
