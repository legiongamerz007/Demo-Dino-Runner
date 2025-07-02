using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isGameActive = false;

    public GameObject menuUI;
    public GameObject scoreUI;
    public GameObject dino;
    public GameObject obstacleSpawner;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0;
        menuUI.SetActive(true);
        scoreUI.SetActive(false);
        // dino.SetActive(false);
        // obstacleSpawner.SetActive(false);
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        menuUI.SetActive(false);
        scoreUI.SetActive(true);
        // dino.SetActive(true);
        // obstacleSpawner.SetActive(true);
    }

    public void EndGame(bool playerWon)
    {
        isGameActive = false;
        // Show win/lose UI, handle rewards, etc.
    }
}
