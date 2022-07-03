using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ObjectTweenAnimator : MonoBehaviour
{
    public enum StopActionType
    {
        None,
        Disable,
        Destroy,
    }

    public List<ObjectTweenAnimationData> animationList;

    [SerializeField]
    private int currentAnimationPlayCount = 0;
    private Coroutine animationCoroutine;

    public StopActionType stopActionType;

    [SerializeField]
    bool autoStartPlay = false;

    private void Start()
    {
        if (autoStartPlay)
            PlayAnimation();
    }

    [Button("½ÇÇà")]
    public virtual void PlayAnimation()
    {
        PlayAnimation(animationList, null);
    }

    public virtual void PlayAnimation(UnityAction completeEvent)
    {
        PlayAnimation(animationList, completeEvent);
    }

    public virtual void PlayAnimation(List<ObjectTweenAnimationData> animations, UnityAction completeEvent = null)
    {
        animationList = animations;
        currentAnimationPlayCount = animations.Count;
        for (var i = 0; i < animations.Count; ++i)
        {
            var animationData = animations[i];
            Tween tween = null;
            switch (animationData.AnimationType)
            {
                case ObjectTweenAnimationType.Move:
                    tween = transform.DOLocalMove(animationData.DestinationVector, animationData.Duration);
                    break;
                case ObjectTweenAnimationType.Rotate:
                    tween = transform.DOLocalRotate(animationData.DestinationVector, animationData.Duration);
                    break;
                case ObjectTweenAnimationType.Scale:
                    tween = transform.DOScale(Vector3.one * animationData.DestinationFloat, animationData.Duration);
                    break;
                case ObjectTweenAnimationType.CameraShakePosition:
                    tween = Camera.main.DOShakePosition(animationData.Duration, animationData.Strength, animationData.Vibrato, animationData.Randomness);
                    break;
                case ObjectTweenAnimationType.CameraShakeRotation:
                    tween = Camera.main.DOShakeRotation(animationData.Duration, animationData.Strength, animationData.Vibrato, animationData.Randomness);
                    break;
                case ObjectTweenAnimationType.CameraFov:
                    if (Camera.main.orthographic)
                    {
                        tween = Camera.main.DOOrthoSize(animationData.DestinationFloat, animationData.Duration);
                    }
                    else
                    {
                        tween = Camera.main.DOFieldOfView(animationData.DestinationFloat, animationData.Duration);
                    }
                    break;
            }

            if (animationData.LoopCount > 0)
            {
                tween.SetLoops(animationData.LoopCount, animationData.LoopType);
            }
            tween.SetDelay(animationData.Delay);
            tween.SetEase(animationData.EaseType);
            tween.OnComplete(() => { --currentAnimationPlayCount; });
            tween.SetRelative(animationData.IsRelative);
            tween.Play();
        }

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        animationCoroutine = StartCoroutine(CoWaitCompleteAnimation(completeEvent));
    }

    private IEnumerator CoWaitCompleteAnimation(UnityAction completeEvent)
    {
        while (currentAnimationPlayCount > 0)
        {
            yield return null;
        }

        completeEvent?.Invoke();
        AutoHide();
        animationCoroutine = null;
    }

    public void AutoHide()
    {
        switch (stopActionType)
        {
            case StopActionType.Disable:
                gameObject.SetActive(false);
                break;
            case StopActionType.Destroy:
                Destroy(gameObject);
                break;
            default: break;
        }
    }

}
