using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private const string GameOverLossTitle = "YOU LOSE";
    private const string GameOverWinTitle = "YOU WIN!";

    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScreenTitle;

    public bool IsGameOver { get; private set; }

    public void GameOverLoss()
    {
        GameOver(GameOverLossTitle);
    }

    public void GameOverWin()
    {
        GameOver(GameOverWinTitle);
    }

    private void GameOver(string title)
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverScreenTitle.SetText(title);
        gameOverScreen.SetActive(true);
    }
}