using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatusType
{
    None,
    /// <summary>
    /// ü��
    /// </summary>
    HP,
    MaxHP,
    /// <summary>
    /// ���ŷ�
    /// </summary>
    MP,
    MaxMP,
    /// <summary>
    /// ���׹̳�
    /// </summary>
    Stemina,
    MaxStemina,
    /// <summary>
    /// ���ݷ�
    /// </summary>
    Attack,
    /// <summary>
    /// ���� Ƚ��
    /// </summary>
    AttackCount,
    /// <summary>
    /// ���ݼӵ�
    /// </summary>
    AttackSpeed,
    /// <summary>
    /// ���߷�
    /// </summary>
    Accuracy,
    /// <summary>
    /// ȸ����
    /// </summary>
    Evasion,
    /// <summary>
    /// ���� ���ݷ�
    /// </summary>
    MeleeAttack,
    /// <summary>
    /// ���� ���ݷ�
    /// </summary>
    MagicAttack,
    /// <summary>
    /// ġ��Ÿ Ȯ��
    /// </summary>
    Critical,
    /// <summary>
    /// ġ��Ÿ ���ط�
    /// </summary>
    CriticalDamage,
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    MoveSpeed,
    /// <summary>
    /// ��ȯ �ӵ�
    /// </summary>
    SummonSpeed,
    /// <summary>
    /// ����
    /// </summary>
    Shield,
    /// <summary>
    /// ü�� �ڿ� ȸ����
    /// </summary>
    RecoverHP,
    /// <summary>
    /// ���ŷ� �ڿ� ȸ����
    /// </summary>
    RecoverMP,
    /// <summary>
    /// ��Ÿ��
    /// </summary>
    CoolTime,
    /// <summary>
    /// �� �׼� ������ �ð�
    /// </summary>
    EnterActionTime,
    /// <summary>
    /// �� �׼� ������ �ð�
    /// </summary>
    ExitActionTime,

    /// <summary>
    /// ��� ȹ��
    /// </summary>
    GainGold,
    /// <summary>
    /// ������ ȹ��
    /// </summary>
    GainItem,
    /// <summary>
    /// ĳ���� �ð�
    /// </summary>
    CastTime,
    /// <summary>
    /// ĳ���� ���� ���� �ð�
    /// </summary>
    CastRangeTime,
    /// <summary>
    /// ���� �ð�
    /// </summary>
    MaintainTime,


    /// <summary>
    /// ��
    /// </summary>
    Strength,
    /// <summary>
    /// ��ø
    /// </summary>
    Agility,
    /// <summary>
    /// ����
    /// </summary>
    Intellect,
    /// <summary>
    /// �ŷ�
    /// </summary>
    Narration,
    /// <summary>
    /// ȭ��
    /// </summary>
    Charm,
    /// <summary>
    /// ������
    /// </summary>
    Morality,

}
