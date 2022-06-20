using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScheduleData", menuName = "Schedule/ScheduleData", order = 0)]
public class ScheduleData : ScriptableObject
{
    public int id;
    public string scheduleName;
    public string description;

    public List<ScheduleScenarioData> scenarioDatas;
}
