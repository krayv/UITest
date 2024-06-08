using UnityEngine.UI;
using UnityEngine;

public class SettingsWindow: UIWindow
{
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(OnClickCloseButton);
        _musicToggle.onValueChanged.AddListener(OnToggleMusic);
        _soundToggle.onValueChanged.AddListener(OnToggleSound);
    }

    protected void OnEnable()
    {
        _musicToggle.SetIsOnWithoutNotify(SoundController.IsMusicEnabled);
        _soundToggle.SetIsOnWithoutNotify(SoundController.IsSoundsEnabled);
    }

    private void OnToggleSound(bool value)
    {
        _eventBus.OnToggleSound?.Invoke(value);
        PlayOnClickSound();
    }

    private void OnToggleMusic(bool value)
    {
        _eventBus.OnToggleMusic?.Invoke(value);
        PlayOnClickSound();
    }

    public void OnClickCloseButton()
    {
        _eventBus.OnClickCloseSettingButton.Invoke();
        PlayOnClickSound();
    }
}