using UnityEngine;
using UnityEngine.UI;

public class StartWindow : UIWindow
{
    [SerializeField] private Button _nextButton;

    protected void Awake()
    {
        _nextButton.onClick.AddListener(OnClickNextButton);
    }

    public void OnClickNextButton()
    {
        _eventBus.OnClickNextButton?.Invoke();
        PlayOnClickSound();
    }
}
