using System;
using UnityEngine;

public abstract class AnimationConfig : ScriptableObject
{
    public float _time;
    public abstract void Play(UIWindow uiWindow, Action callback);
}
