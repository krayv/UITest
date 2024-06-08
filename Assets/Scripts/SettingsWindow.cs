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
    }

    public void OnClickCloseButton()
    {
        _eventBus.OnClickCloseSettingButton.Invoke();
    }
}