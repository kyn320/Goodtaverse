using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DayNightRuleData", menuName = "World/DayNightRuleData", order = 0)]
public class DayNightRuleData : ScriptableObject
{
    public float dayTime;
        
    public SerializableDictionary<DayTimeType,float> dayTimeDic = new SerializableDictionary<DayTimeType, float>();
    public SerializableDictionary<DayTimeType, AmountRangeFloat> dayLightDic = new SerializableDictionary<DayTimeType, AmountRangeFloat>();
    
}
