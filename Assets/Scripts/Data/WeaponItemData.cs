using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItemData", menuName = "Item/WeaponItemData", order = 0)]
public class WeaponItemData : ItemData
{
    public EquipType equipType;
    public WeaponType weaponType;
    public GameObject weaponObject;
    public List<AttackInfoData> chainInfoList;
}
