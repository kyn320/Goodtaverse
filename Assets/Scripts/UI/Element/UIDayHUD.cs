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
        //TODO :: 12�ð��� ������ ��� ������ ó���ؾߵǴµ�..
        //�ð� ������ �ֳ�..?
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
