using System;
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

    public Action PlayerDied { get; set; }

    private void Start()
    {
        CurrentLives = lives;
    }

    public void Hit()
    {
        AudioManager.Instance.SfxAudioSource.PlayOneShot(hitSound);
        cameraManager.RedFlash();
        CurrentLives--;
        if (!IsDead)
        {
            return;
        }
        PlayerDied?.Invoke();
        gameOverManager.GameOverLoss();
    }
}