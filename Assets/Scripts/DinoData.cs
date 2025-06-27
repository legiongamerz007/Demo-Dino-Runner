using UnityEngine;

[CreateAssetMenu(fileName = "DinoData", menuName = "Dino/DinoData", order = 1)]
public class DinoData : ScriptableObject
{
    public string dinoName;
    public Sprite dinoSprite;
    public float speed;
    public float jumpForce;
    // Add more stats as needed (e.g., acceleration, special abilities)
} 