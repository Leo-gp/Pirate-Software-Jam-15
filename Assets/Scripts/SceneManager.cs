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
}