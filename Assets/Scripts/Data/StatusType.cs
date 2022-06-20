using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatusType
{
    None,
    /// <summary>
    /// 체력
    /// </summary>
    HP,
    MaxHP,
    /// <summary>
    /// 정신력
    /// </summary>
    MP,
    MaxMP,
    /// <summary>
    /// 스테미나
    /// </summary>
    Stemina,
    MaxStemina,
    /// <summary>
    /// 공격력
    /// </summary>
    Attack,
    /// <summary>
    /// 공격 횟수
    /// </summary>
    AttackCount,
    /// <summary>
    /// 공격속도
    /// </summary>
    AttackSpeed,
    /// <summary>
    /// 명중률
    /// </summary>
    Accuracy,
    /// <summary>
    /// 회피율
    /// </summary>
    Evasion,
    /// <summary>
    /// 물리 공격력
    /// </summary>
    MeleeAttack,
    /// <summary>
    /// 마법 공격력
    /// </summary>
    MagicAttack,
    /// <summary>
    /// 치명타 확률
    /// </summary>
    Critical,
    /// <summary>
    /// 치명타 피해량
    /// </summary>
    CriticalDamage,
    /// <summary>
    /// 이동 속도
    /// </summary>
    MoveSpeed,
    /// <summary>
    /// 소환 속도
    /// </summary>
    SummonSpeed,
    /// <summary>
    /// 쉴드
    /// </summary>
    Shield,
    /// <summary>
    /// 체력 자연 회복량
    /// </summary>
    RecoverHP,
    /// <summary>
    /// 정신력 자연 회복량
    /// </summary>
    RecoverMP,
    /// <summary>
    /// 쿨타임
    /// </summary>
    CoolTime,
    /// <summary>
    /// 선 액션 딜레이 시간
    /// </summary>
    EnterActionTime,
    /// <summary>
    /// 후 액션 딜레이 시간
    /// </summary>
    ExitActionTime,

    /// <summary>
    /// 골드 획득
    /// </summary>
    GainGold,
    /// <summary>
    /// 아이템 획득
    /// </summary>
    GainItem,
    /// <summary>
    /// 캐스팅 시간
    /// </summary>
    CastTime,
    /// <summary>
    /// 캐스팅 성공 범위 시간
    /// </summary>
    CastRangeTime,
    /// <summary>
    /// 유지 시간
    /// </summary>
    MaintainTime,


    /// <summary>
    /// 힘
    /// </summary>
    Strength,
    /// <summary>
    /// 민첩
    /// </summary>
    Agility,
    /// <summary>
    /// 지능
    /// </summary>
    Intellect,
    /// <summary>
    /// 매력
    /// </summary>
    Narration,
    /// <summary>
    /// 화술
    /// </summary>
    Charm,
    /// <summary>
    /// 도덕성
    /// </summary>
    Morality,

}
