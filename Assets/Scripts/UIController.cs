using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private List<UIWindow> _windows;

    private EventBus _eventBus;

    private UIWindow _currentWindow;


    public void OpenWindow<T>(Action callback) where T : UIWindow
    {
        CloseCurrentWindow(() =>
        {
            var window = _windows.OfType<T>().FirstOrDefault();
            window.Open(callback);
            _currentWindow = window;
        });
    }

    public void CloseCurrentWindow(Action callback)
    {
        if (_currentWindow != null)
            _currentWindow.Close(callback);
        else
        {
            callback.Invoke();
        }
    }

    public void Init(EventBus eventBus)
    {
        DontDestroyOnLoad(this.gameObject);
        _eventBus = eventBus;

        foreach (UIWindow window in _windows)
        {
            window.Init(_eventBus);
        }
        SetEvents();
        OpenWindow<StartWindow>(() => { });
    }

    private void SetEvents()
    {
        _eventBus.OnClickNextButton += OnClickNextButton;
        _eventBus.OnClickRestartButton += OnClickRestartButton;
        _eventBus.OnClickCloseSettingButton += OnClickCloseSettingsButton;
        _eventBus.OnClickSettingsButton += OnClickSettingsButton;
        _eventBus.OnCallLoadScene += OnCallLoadScene;
        _eventBus.OnLoadScene += OnLoadScene;
    }
    private void OnClickNextButton()
    {
        _eventBus.OnCallLoadScene?.Invoke(LoadSceneController.MAIN_SCENE_NAME);
    }

    private void OnClickRestartButton()
    {
        _eventBus.OnCallLoadScene?.Invoke(LoadSceneController.MAIN_SCENE_NAME);
    }

    private void OnCallLoadScene(string sceneName)
    {
        OpenWindow<PreloadWindow>(() =>
        {
            _eventBus.OnStartLoadScene(sceneName);
        });

    }

    private void OnLoadScene(string sceneName)
    {
        if (LoadSceneController.MAIN_SCENE_NAME == sceneName)
        {
            OpenWindow<MainWindow>(() => { });
        }
    }

    private void OnClickSettingsButton()
    {
        OpenWindow<SettingsWindow>(() => { });
    }

    private void OnClickCloseSettingsButton()
    {
        if (_currentWindow is SettingsWindow)
            CloseCurrentWindow(() => { });
    }
}
