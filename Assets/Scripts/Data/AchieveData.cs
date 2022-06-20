using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "AchieveData", menuName = "Achieve/AchieveData", order = 0)]
public class AchieveData : ScriptableObject
{
    public AchieveType achieveType;
    public string achieveName;
    public Sprite thumbnail;
    [TextArea]
    public string description;


}
