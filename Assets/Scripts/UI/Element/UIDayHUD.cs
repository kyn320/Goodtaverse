using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDayHUD : MonoBehaviour
{
    [SerializeField]
    protected UIAmountText dayAmountText;

    [SerializeField]
    protected UIBaseGauge dayGauge;

    private void Start()
    {
        DayNightSystem.Instance.updateHourTimeEvent.AddListener(UpdateHour);
    }

    public void UpdateHour(DayTimeType dayTimeType, float currentHour, float maxHour)
    {
        //TODO :: 12시간을 나눠서 밤과 낮으로 처리해야되는데..
        //시간 구간이 있네..?
        dayGauge.UpdateGauge(currentHour, maxHour);
    }

    public void UpdateDayAmount(int day)
    {
        dayAmountText.UpdateAmount(day);
    }

    private void OnDestroy()
    {
        DayNightSystem.Instance.updateHourTimeEvent.RemoveListener(UpdateHour);
    }

}
