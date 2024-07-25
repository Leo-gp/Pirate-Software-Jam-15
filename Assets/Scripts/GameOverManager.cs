using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private const string GameOverLossTitle = "YOU LOSE";

    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScreenTitle;

    public bool IsGameOver { get; private set; }

    public void GameOverLoss()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverScreenTitle.SetText(GameOverLossTitle);
        gameOverScreen.SetActive(true);
    }
}