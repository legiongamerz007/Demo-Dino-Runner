using System.Collections.Generic;
using UnityEngine;

public class DinoManager : MonoBehaviour
{
    public static DinoManager Instance { get; private set; }

    public List<DinoData> allDinos; // Assign all available dinos in inspector
    public List<DinoData> ownedDinos; // Assign owned dinos in inspector (or load from save)
    public DinoData selectedDino;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SelectDino(DinoData dino)
    {
        selectedDino = dino;
        // Save selection if needed
    }

    public bool IsOwned(DinoData dino)
    {
        return ownedDinos.Contains(dino);
    }
} 