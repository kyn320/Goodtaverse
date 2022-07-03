using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UITweenAnimator : MonoBehaviour
{
    public enum StopActionType
    {
        None,
        Disable,
        Destroy,
    }

    public List<UIAnimationData> animationList;

    [SerializeField]
    private int currentAnimationPlayCount = 0;
    private Coroutine animationCoroutine;

    public StopActionType stopActionType;


    public virtual void PlayAnimation()
    {
        PlayAnimation(animationList, null);
    }

    public virtual void PlayAnimation(UnityAction completeEvent)
    {
        PlayAnimation(animationList, completeEvent);
    }

    public virtual void PlayAnimation(List<UIAnimationData> animations, UnityAction completeEvent = null)
    {
        currentAnimationPlayCount = animations.Count;
        for (var i = 0; i < animations.Count; ++i)
        {
            var animationData = animations[i];
            Tween tween = null;
            switch (animationData.AnimationType)
            {
                case UIAnimationType.Move:
                    tween = transform.DOLocalMove(animationData.DestinationVector, animationData.Duration);
                    break;
                case UIAnimationType.Rotate:
                    tween = transform.DOLocalRotate(animationData.DestinationVector, animationData.Duration);
                    break;
                case UIAnimationType.Scale:
                    tween = transform.DOScale(Vector3.one * animationData.DestinationFloat, animationData.Duration);
                    break;
                case UIAnimationType.Color:
                    tween = GetComponent<Graphic>()?.DOColor(animationData.DestinationColor, animationData.Duration);
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

        animationCoroutine = StartCoroutine("CoWaitCompleteAnimation", completeEvent);
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
