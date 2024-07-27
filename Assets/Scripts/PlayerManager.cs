using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private int lives;

    public int CurrentLives { get; private set; }

    public Transform PlayerPosition => playerPosition;

    private void Start()
    {
        CurrentLives = lives;
    }

    public void Hit()
    {
        cameraManager.RedFlash();
        CurrentLives--;
        if (CurrentLives <= 0)
        {
            gameOverManager.GameOverLoss();
        }
    }
}