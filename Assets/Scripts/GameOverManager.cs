using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameOverLossScreen;
    [SerializeField] private GameObject gameOverWinScreen;

    public bool IsGameOver { get; private set; }

    public void GameOverLoss()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverLossScreen.SetActive(true);
    }

    public void GameOverWin()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverWinScreen.SetActive(true);
    }
}