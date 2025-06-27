using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LandingUIManager : MonoBehaviour
{
    public Image dinoImage;
    public TMP_Text dinoNameText;
    public Button selectDinoButton;
    public Button playButton;

    private void Start()
    {
        UpdateSelectedDinoUI();
        selectDinoButton.onClick.AddListener(OpenDinoSelection);
        playButton.onClick.AddListener(StartGame);
    }

    public void UpdateSelectedDinoUI()
    {
        var dino = DinoManager.Instance.selectedDino;
        if (dino != null)
        {
            dinoImage.sprite = dino.dinoSprite;
            dinoNameText.text = dino.dinoName;
        }
    }

    private void OpenDinoSelection()
    {
        // Load or activate dino selection UI/scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("DinoSelection");
    }

    private void StartGame()
    {
        // Load the main game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
} 