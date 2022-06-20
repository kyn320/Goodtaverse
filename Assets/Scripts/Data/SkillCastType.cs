using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SkillCastType
{

    None,
    /// <summary>
    /// 즉발
    /// </summary>
    Immediate,
    /// <summary>
    /// 홀드
    /// </summary>
    Hold,
    /// <summary>
    /// 캐스팅
    /// </summary>
    Cast,
    /// <summary>
    /// 패시브
    /// </summary>
    Passive,

}
