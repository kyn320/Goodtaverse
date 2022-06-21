using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackInfoData",menuName = "Attack/AttackInfo",order = 0)]
public class AttackInfoData : ScriptableObject
{
    public string attackName;

    public StatusInfoData statusInfoData;

    public float waitForStartTime = 1;
    public float attackTime = 2;
    public float waitForEndTime = 1;

    public List<AnimatorTriggerData> startTriggerList = new List<AnimatorTriggerData>();
    public List<AnimatorTriggerData> updateTriggerList = new List<AnimatorTriggerData>();
    public List<AnimatorTriggerData> endTriggerList = new List<AnimatorTriggerData>();

    public GameObject attackVfx;
    public GameObject damagedVfx;
}
