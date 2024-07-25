using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;

    private bool _isPaused;

    public void TogglePauseMenu()
    {
        if (gameOverManager.IsGameOver)
        {
            return;
        }
        if (!_isPaused)
        {
            pauseMenu.SetActive(true);
            Pause();
        }
        else
        {
            pauseMenu.SetActive(false);
            Unpause();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        playerController.DisablePlayerInput();
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        _isPaused = false;
        playerController.EnablePlayerInput();
        Time.timeScale = 1;
    }
}