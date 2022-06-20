using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SkillData", order = 0)]
public class SkillData : ScriptableObject
{
    public int id;
    public string skillName;
    [TextArea]
    public string description;
    public Sprite icon;

    public List<WeaponType> allowTypeList;
    public SkillCastType castType;
    public SkillActionType actionType;

    public StatusInfo originStatusInfo;
    public float castCenterTime;
    public List<AmountRangeFloat> holdLevelList;

    public StatusInfo addStatusInfo;
    public StatusInfo subStatusInfo;

    public GameObject skillObject;

    public bool CheckAllowWeapon(WeaponType weaponType) { 
        return allowTypeList.Contains(weaponType);
    }
}
