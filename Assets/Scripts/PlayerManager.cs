using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private Transform playerPosition;

    public Transform PlayerPosition => playerPosition;

    public void Hit()
    {
        cameraManager.RedFlash();
    }
}