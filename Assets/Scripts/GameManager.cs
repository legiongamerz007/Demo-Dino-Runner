using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject scoreUI;
    public GameObject dino;
    public GameObject obstacleSpawner;

    void Start()
    {
        Time.timeScale = 0;
        menuUI.SetActive(true);
        scoreUI.SetActive(false);
        dino.SetActive(false);
        obstacleSpawner.SetActive(false);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        scoreUI.SetActive(true);
        dino.SetActive(true);
        obstacleSpawner.SetActive(true);
    }
}
