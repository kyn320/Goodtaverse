using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleScenarioData : ScriptableObject
{
    [TextArea]
    public List<string> talkDataList;

    public List<int> rewardItemList;
    public StatusInfo rewardStatus;

    //TODO :: NPC ���� ����?
    //Ư�� �ó����� ����?
    public AmountRangeFloat meetPercent;
}
