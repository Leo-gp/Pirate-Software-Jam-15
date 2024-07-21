using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Image redImage;
    [SerializeField] private TweenSettings<float> redFlashTweenSettings;

    public void RedFlash()
    {
        Tween.Alpha(redImage, redFlashTweenSettings);
    }
}