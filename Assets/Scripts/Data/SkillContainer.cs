using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "SkillContainer", menuName = "Skill/SkillContainer", order = 0)]
public class SkillContainer : SerializedScriptableObject
{
    public List<SkillData> skillList = new List<SkillData>();

    public List<SkillData> GetSkillList(WeaponType weaponType, SkillCastType castType)
    {
        if (weaponType == WeaponType.None && castType == SkillCastType.None)
        {
            return skillList;
        }
        else if (weaponType == WeaponType.None || castType != SkillCastType.None)
        {
            return skillList.FindAll(item => item.castType == castType);
        }
        else if (weaponType != WeaponType.None || castType == SkillCastType.None)
        {
            return skillList.FindAll(item => item.CheckAllowWeapon(weaponType));
        }
        else
        {
            return skillList.FindAll(item => item.castType == castType && item.CheckAllowWeapon(weaponType));
        }
    }

}
