using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private int lives;

    public int CurrentLives { get; private set; }

    public Transform PlayerPosition => playerPosition;

    public bool IsDead => CurrentLives <= 0;

    private void Start()
    {
        CurrentLives = lives;
    }

    public void Hit()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(hitSound);
        cameraManager.RedFlash();
        CurrentLives--;
        if (IsDead)
        {
            gameOverManager.GameOverLoss();
        }
    }
}