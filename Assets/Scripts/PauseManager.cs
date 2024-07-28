using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button firstSelectedButton;

    private bool _isPaused;

    public void TogglePauseMenu()
    {
        if (gameOverManager.IsGameOver)
        {
            return;
        }
        if (!_isPaused)
        {
            pauseScreen.SetActive(true);
            Pause();
        }
        else
        {
            pauseScreen.SetActive(false);
            Unpause();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        playerController.DisablePlayerInput();
        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        _isPaused = false;
        playerController.EnablePlayerInput();
        Time.timeScale = 1;
    }
}