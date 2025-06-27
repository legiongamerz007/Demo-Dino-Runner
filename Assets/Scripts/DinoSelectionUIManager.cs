using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DinoSelectionUIManager : MonoBehaviour
{
    public Transform dinoListParent;
    public GameObject dinoButtonPrefab;
    public TMP_Text infoText;
    public Button confirmButton;

    private DinoData selectedDino;

    void Start()
    {
        PopulateDinoList();
        confirmButton.onClick.AddListener(ConfirmSelection);
    }

    void PopulateDinoList()
    {
        foreach (Transform child in dinoListParent)
            Destroy(child.gameObject);

        foreach (var dino in DinoManager.Instance.allDinos)
        {
            var btnObj = Instantiate(dinoButtonPrefab, dinoListParent);
            var btn = btnObj.GetComponent<Button>();
            var txt = btnObj.GetComponentInChildren<TMP_Text>();
            txt.text = dino.dinoName;
            btn.image.sprite = dino.dinoSprite;
            btn.interactable = DinoManager.Instance.IsOwned(dino);
            btn.onClick.AddListener(() => OnDinoSelected(dino));
        }
    }

    void OnDinoSelected(DinoData dino)
    {
        selectedDino = dino;
        infoText.text = $"{dino.dinoName}\nSpeed: {dino.speed}\nJump: {dino.jumpForce}";
    }

    void ConfirmSelection()
    {
        if (selectedDino != null && DinoManager.Instance.IsOwned(selectedDino))
        {
            DinoManager.Instance.SelectDino(selectedDino);
            // Return to landing or main menu
            UnityEngine.SceneManagement.SceneManager.LoadScene("Landing");
        }
    }
} 