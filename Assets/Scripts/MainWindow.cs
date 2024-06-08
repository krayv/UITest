using UnityEngine.UI;
using UnityEngine;

public class MainWindow : UIWindow
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _settingsButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnClickRestartButton);
        _settingsButton.onClick.AddListener(OnClickSettingsButton);
    }

    public void OnClickRestartButton()
    {
        _eventBus.OnClickRestartButton.Invoke();
        PlayOnClickSound();
    }

    public void OnClickSettingsButton()
    {
        _eventBus.OnClickSettingsButton.Invoke();
        PlayOnClickSound();
    }
}