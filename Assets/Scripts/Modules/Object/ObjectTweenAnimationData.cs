using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening;

public enum ObjectTweenAnimationType
{
    None,
    Move,
    Rotate,
    Scale,
    Color
}

[CreateAssetMenu(fileName = "ObjectTweenAnimationData", menuName = "GameObject/TweenAnimationData", order = int.MaxValue)]
public class ObjectTweenAnimationData : ScriptableObject
{
    [SerializeField]
    private string animationName;
    public string AnimationName { get { return animationName; } }

    [SerializeField]
    private float duration;
    public float Duration { get { return duration; } }

    [SerializeField]
    private float delay;
    public float Delay { get { return delay; } }

    [SerializeField]
    private ObjectTweenAnimationType animationType;
    public ObjectTweenAnimationType AnimationType { get { return animationType; } }

    [SerializeField]
    private Ease easeType;
    public Ease EaseType { get { return easeType; } }

    [SerializeField]
    private AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    public AnimationCurve EaseCurve { get { return easeCurve; } }

    [SerializeField]
    private int loopCount;
    public int LoopCount { get { return loopCount; } }

    [SerializeField]
    private LoopType loopType;
    public LoopType LoopType { get { return loopType; } }

    [SerializeField]
    private float destinationFloat;
    public float DestinationFloat { get { return destinationFloat; } }

    [SerializeField]
    private Vector3 destinationVector;
    public Vector3 DestinationVector { get { return destinationVector; } }

    [SerializeField]
    private bool isRelative;
    public bool IsRelative { get { return isRelative; } }
}
