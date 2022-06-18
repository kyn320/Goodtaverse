using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "StatusInfoData", menuName = "Status/StatusInfo", order = 0)]
public class AchieveData : ScriptableObject
{
    public AchieveType achieveType;
    public string achieveName;
    public Sprite thumbnail;
    public string description;
}
