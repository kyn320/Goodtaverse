using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UILoadingView : UIBaseView
{

    public AmountRangeFloat viewTimeRange;

    private Coroutine viewWaitCoroutine;

    public override void Init(UIData uiData)
    {

    }

    private void Start()
    {
        FadeController.Instance.SetActive(false);
        StartCoroutine(CoWaitForViewTime());
    }

    private IEnumerator CoWaitForViewTime() { 
        var time = viewTimeRange.GetRandomAmount();

        while(time >= 0) { 
            time -= Time.deltaTime;
            yield return null;
        }

        FadeController.Instance.SetActive(true);
        SceneLoader.Instance.LoadNextScene();
    }

}
