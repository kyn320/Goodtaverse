using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SkillData", order = 0)]
public class SkillData : ScriptableObject
{
    public int id;
    public string skillName;
    public string description;
    public Sprite icon;

    public float coolTime;
    public GameObject skillObject;
}
