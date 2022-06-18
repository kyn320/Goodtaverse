using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class StatusElement
{
    public StatusType type;
    public string name;
    public float amount;
    public float percent;

    public StatusElement()
    {

    }

    public StatusElement(StatusType type, string name, float amount, float percent)
    {
        this.type = type;
        this.name = name;
        this.amount = amount;
        this.percent = percent;
    }
    public StatusElement(StatusElement copyElement)
    {
        this.type = copyElement.type;
        this.name = copyElement.name;
        this.amount = copyElement.amount;
        this.percent = copyElement.percent;
    }

    public virtual float CalculateAmount(float origin)
    {
        return origin + amount;
    }

    public virtual float GetPercentAmount(float origin)
    {
        return origin * percent;
    }

    public virtual float CalculatePercent(float origin)
    {
        return origin + (origin * percent);
    }

}