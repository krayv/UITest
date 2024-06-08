using DG.Tweening;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/OpenAnimation")]
public class OpenAnimation : AnimationConfig
{
    [SerializeField] private Vector2 _startPositionOffset = new Vector2(0, 1000);
    public override void Play(UIWindow window, Action callback)
    {
        Sequence sequence = DOTween.Sequence();
        window.transform.position += (Vector3)_startPositionOffset;
        sequence.Append(window.transform.DOMoveY(window.transform.position.y - _startPositionOffset.y, _time));
        window.CanvasGroup.alpha = 0f;
        sequence.Insert(0f, window.CanvasGroup.DOFade(1f, _time));
        sequence.onComplete += () => { callback.Invoke(); };
    }

}
