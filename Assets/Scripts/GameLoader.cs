using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject dinoPrefab; // Assign a generic dino prefab with PlayerDinoController

    void Start()
    {
        var selectedDino = DinoManager.Instance.selectedDino;
        if (selectedDino != null)
        {
            var dinoObj = Instantiate(dinoPrefab, playerSpawnPoint.position, Quaternion.identity);
            var controller = dinoObj.GetComponent<PlayerDinoController>();
            controller.Setup(selectedDino);
        }
    }
} 