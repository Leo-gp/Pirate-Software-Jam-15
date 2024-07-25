using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private int lives;

    private int _currentLives;

    public Transform PlayerPosition => playerPosition;

    private void Start()
    {
        _currentLives = lives;
    }

    public void Hit()
    {
        cameraManager.RedFlash();
        _currentLives--;
        if (_currentLives <= 0)
        {
            gameOverManager.GameOverLoss();
        }
    }
}