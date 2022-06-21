using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DayTimeType 
{
    None,
    /// <summary>
    /// 아침
    /// </summary>
    Morning,
    /// <summary>
    /// 어스름
    /// </summary>
    Overlap,
    /// <summary>
    /// 밤
    /// </summary>
    Night,
}
