using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleScenarioData : ScriptableObject
{
    [TextArea]
    public List<string> talkDataList;

    public List<int> rewardItemList;
    public StatusInfo rewardStatus;

    //TODO :: NPC 조우 가능?
    //특수 시나리오 정보?
    public AmountRangeFloat meetPercent;
}
