using System;
using UnityEngine;

[CreateAssetMenu]
public abstract class AnimationConfig : ScriptableObject
{
    public float _time;
    public abstract void Play(GameObject gameObject, Action callback);
}
