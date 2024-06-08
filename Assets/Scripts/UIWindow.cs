using System;
using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    [SerializeField]
    private AnimationConfig _openAnimation;
    [SerializeField]
    private AnimationConfig _closeAnimation;

    protected EventBus _eventBus;

    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public void Open(Action callback)
    {
        callback += OnEndCloseAnimation;
        gameObject.SetActive(true);
        _openAnimation.Play(gameObject, callback);
    }

    protected virtual void OnEndOpenAnimation()
    {

    }

    public void Close(Action callback)
    {
        callback += OnEndCloseAnimation;
        _openAnimation.Play(gameObject, callback);
    }

    protected virtual void OnEndCloseAnimation()
    {
        gameObject.SetActive(false);
    }
}
