using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class DayNightSystem : Singleton<DayNightSystem>
{
    [SerializeField]
    protected DayNightRuleData dayNightRule;

    protected DayTimeType currentDayType;
    protected Light sunLight;
    protected DateTime worldDate;
    private float todayTime;

    public UnityEvent<DayTimeType, float, float> updateHourTimeEvent;
    public UnityEvent<float, float> updateTodayTimeEvent;
    public UnityEvent<DateTime> updateWorldDateEvent;

    protected bool isUpdateTime = false;

    [Button("Start World Clock")]
    public void UseUpdateTime(bool isUpdate)
    {
        isUpdateTime = isUpdate;
        currentDayType = DayTimeType.Morning;
    }

    public void SetSunLight(Light sun)
    {
        sunLight = sun;
    }

    private void Update()
    {
        if (!isUpdateTime)
            return;

        todayTime += Time.deltaTime;
        updateTodayTimeEvent?.Invoke(todayTime, dayNightRule.dayTime);
        updateHourTimeEvent?.Invoke(DayTimeType.Morning, todayTime, dayNightRule.dayTime);
        sunLight.intensity = dayNightRule.dayLightDic[currentDayType].GetRange(todayTime / dayNightRule.dayTime);

        worldDate.AddHours((Time.deltaTime / dayNightRule.dayTime) * 24f);

        if (todayTime >= dayNightRule.dayTime)
        {
            updateWorldDateEvent?.Invoke(worldDate);
        }
    }

}
