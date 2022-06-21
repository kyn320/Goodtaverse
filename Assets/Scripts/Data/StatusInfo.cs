using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[System.Serializable]
public class StatusInfo
{
    [SerializeField]
    public SerializableDictionary<StatusType, StatusElement> statusDic = new SerializableDictionary<StatusType, StatusElement>();

    public void Copy(Dictionary<StatusType, StatusElement> copyDic)
    {
        statusDic.Clear();

        var keyList = copyDic.Keys.ToList();
        for (var i = 0; i < keyList.Count; ++i)
        {
            statusDic.Add(keyList[i], new StatusElement(copyDic[keyList[i]]));
        }
    }

    public StatusElement GetElement(StatusType statusType) {
        return statusDic[statusType];
    }

    public float CalculateDamage()
    {
        var damage = statusDic[StatusType.Attack].GetAmount();
        return damage;
    }

    public float CalculateDefence(float damage)
    {
        var defenceDamage = damage - statusDic[StatusType.Shield].GetAmount();
        return 0;
    }
}
