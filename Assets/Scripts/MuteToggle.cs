using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    private static bool _isMute;

    [SerializeField] private Toggle muteToggle;

    private void Start()
    {
        muteToggle.onValueChanged.AddListener(SetAudioMute);
        muteToggle.isOn = _isMute;
    }

    private void OnDestroy()
    {
        muteToggle.onValueChanged.RemoveListener(SetAudioMute);
    }

    private static void SetAudioMute(bool value)
    {
        _isMute = AudioManager.Instance.SfxAudioSource.mute = AudioManager.Instance.MusicAudioSource.mute = value;
    }
}