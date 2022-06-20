using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum KeyType 
{
    None,
    /// <summary>
    /// �� �̵�
    /// </summary>
    MoveUp,
    /// <summary>
    /// �Ʒ� �̵�
    /// </summary>
    MoveDown,
    /// <summary>
    /// ���� �̵�
    /// </summary>
    MoveLeft,
    /// <summary>
    /// ������ �̵�
    /// </summary>
    MoveRight,

    /// <summary>
    /// ���� 
    /// </summary>
    Attack,
    /// <summary>
    /// ��ȣ�ۿ�
    /// </summary>
    Interaction,
    /// <summary>
    /// ķ�� ������
    /// </summary>
    CampingItem,
    /// <summary>
    /// �Ҹ� ������ 1
    /// </summary>
    Item1,
    /// <summary>
    /// �Ҹ� ������ 2
    /// </summary>
    Item2,
    /// <summary>
    /// �Ҹ� ������ 3
    /// </summary>
    Item3,
    /// <summary>
    /// �Ҹ� ������ 4
    /// </summary>
    Item4,

    /// <summary>
    /// ��ų ���� 1
    /// </summary>
    Skill1,
    /// <summary>
    /// ��ų ���� 2
    /// </summary>
    Skill2,
    /// <summary>
    /// ��ų ���� 3
    /// </summary>
    Skill3,
    /// <summary>
    /// ��ų ���� 4
    /// </summary>
    Skill4,

    /// <summary>
    /// �κ��丮
    /// </summary>
    Inevntory,
    /// <summary>
    /// ����
    /// </summary>
    Map,
    /// <summary>
    /// �޴�(�Ͻ�����)
    /// </summary>
    Menu,
}
