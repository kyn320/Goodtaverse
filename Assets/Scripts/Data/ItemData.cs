using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite icon;

    public StatusInfo addStatusInfo;
    public StatusInfo subStatusInfo;

    public int buyGold;
    public int sellGold;

    public Vector2Int size;
}



