using System;
using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    [SerializeField]
    private AnimationConfig _openAnimation;
    [SerializeField]
    private AnimationConfig _closeAnimation;
    [SerializeField]
    private CanvasGroup _canvasGroup;

    public CanvasGroup CanvasGroup => _canvasGroup;

    protected EventBus _eventBus;

    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public void Open(Action callback)
    {
        callback += OnEndOpenAnimation;
        gameObject.SetActive(true);
        _openAnimation.Play(this, callback);
        _canvasGroup.interactable = true;
    }

    protected virtual void OnEndOpenAnimation()
    {

    }

    public void Close(Action callback)
    {
        callback += OnEndCloseAnimation;
        _closeAnimation.Play(this, callback);
        _canvasGroup.interactable = false;
    }

    protected virtual void OnEndCloseAnimation()
    {
        gameObject.SetActive(false);
    }
}
