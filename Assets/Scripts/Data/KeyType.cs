using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum KeyType 
{
    None,
    /// <summary>
    /// 위 이동
    /// </summary>
    MoveUp,
    /// <summary>
    /// 아래 이동
    /// </summary>
    MoveDown,
    /// <summary>
    /// 왼쪽 이동
    /// </summary>
    MoveLeft,
    /// <summary>
    /// 오른쪽 이동
    /// </summary>
    MoveRight,

    /// <summary>
    /// 공격 
    /// </summary>
    Attack,
    /// <summary>
    /// 상호작용
    /// </summary>
    Interaction,
    /// <summary>
    /// 캠핑 아이템
    /// </summary>
    CampingItem,
    /// <summary>
    /// 소모 아이템 1
    /// </summary>
    Item1,
    /// <summary>
    /// 소모 아이템 2
    /// </summary>
    Item2,
    /// <summary>
    /// 소모 아이템 3
    /// </summary>
    Item3,
    /// <summary>
    /// 소모 아이템 4
    /// </summary>
    Item4,

    /// <summary>
    /// 스킬 슬롯 1
    /// </summary>
    Skill1,
    /// <summary>
    /// 스킬 슬롯 2
    /// </summary>
    Skill2,
    /// <summary>
    /// 스킬 슬롯 3
    /// </summary>
    Skill3,
    /// <summary>
    /// 스킬 슬롯 4
    /// </summary>
    Skill4,

    /// <summary>
    /// 인벤토리
    /// </summary>
    Inevntory,
    /// <summary>
    /// 지도
    /// </summary>
    Map,
    /// <summary>
    /// 메뉴(일시정지)
    /// </summary>
    Menu,
}
