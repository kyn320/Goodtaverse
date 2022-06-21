using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    Camera cam;

    [SerializeField]
    ObjectTweenAnimator damagedAnimation;

    [SerializeField]
    ObjectTweenAnimator hitAnimation;

    protected override void Awake()
    {
        base.Awake();
        cam = GetComponent<Camera>();
    }

    public void AnimateDamaged()
    {
        damagedAnimation.PlayAnimation();
    }

    public void AnimateHit()
    {
        hitAnimation.PlayAnimation();
    }
}
