using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameOverLossScreen;
    [SerializeField] private GameObject gameOverWinScreen;
    [SerializeField] private Button gameOverLossFirstSelectedButton;
    [SerializeField] private Button gameOverWinFirstSelectedButton;

    public bool IsGameOver { get; private set; }

    public void GameOverLoss()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverLossScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameOverLossFirstSelectedButton.gameObject);
    }

    public void GameOverWin()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverWinScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameOverWinFirstSelectedButton.gameObject);
    }
}