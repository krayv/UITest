using DG.Tweening;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/CloseAnimation")]
public class CloseAnimation : AnimationConfig
{
    [SerializeField] private Vector2 _endPositionOffset = new Vector2(0, 1000);

    public override void Play(UIWindow window, Action callback)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(window.transform.DOMoveY(window.transform.position.y - _endPositionOffset.y, _time));
        window.CanvasGroup.alpha = 1f;
        sequence.Insert(0f, window.CanvasGroup.DOFade(0f, _time));
        sequence.onComplete += () => 
        {
            window.transform.position += (Vector3) _endPositionOffset;
            callback.Invoke(); 
        };
    }
}
