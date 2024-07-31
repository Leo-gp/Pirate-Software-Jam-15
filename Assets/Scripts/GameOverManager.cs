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
    [SerializeField] private AudioClip gameOverLossSound;
    [SerializeField] private AudioClip gameOverWinSound;

    public bool IsGameOver { get; private set; }

    public void GameOverLoss()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverLossScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameOverLossFirstSelectedButton.gameObject);
        AudioManager.Instance.SfxAudioSource.PlayOneShot(gameOverLossSound);
    }

    public void GameOverWin()
    {
        IsGameOver = true;
        pauseManager.Pause();
        gameOverWinScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameOverWinFirstSelectedButton.gameObject);
        AudioManager.Instance.SfxAudioSource.PlayOneShot(gameOverWinSound);
    }
}