using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "StatusInfoData", menuName = "Status/StatusInfo", order = 0)]
public class StatusInfoData : SerializedScriptableObject
{
    [SerializeField]
    public SerializableDictionary<StatusType, StatusElement> statusDic = new SerializableDictionary<StatusType, StatusElement>();

}
