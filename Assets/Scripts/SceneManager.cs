using PrimeTween;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void RestartScene()
    {
        Tween.StopAll();
        var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene.buildIndex);
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        Tween.StopAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Tween.StopAll();
        Application.Quit();
        Time.timeScale = 1;
    }
}