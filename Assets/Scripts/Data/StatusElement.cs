using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[System.Serializable]
public class StatusElement
{
    public StatusType type;
    public string name;
    [SerializeField]
    protected float amount;
    [SerializeField]
    protected float percent;

    public UnityEvent<float> updateAmountEvent;
    public UnityEvent<float> updatePercentEvent;

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

    public void SetAmount(float amount)
    {
        this.amount = amount;
        updateAmountEvent?.Invoke(amount);
    }

    public void AddAmount(float amount) {
        this.amount += amount;
        updateAmountEvent?.Invoke(amount);
    }

    public float GetAmount() { 
        return amount;
    }

    public void SetPercent(float percent)
    {
        this.percent = percent;
        updatePercentEvent?.Invoke(percent);
    }
    public void AddPercent(float percent)
    {
        this.percent += percent;
        updatePercentEvent?.Invoke(percent);
    }

    public float GetPercent()
    {
        return percent;
    }
}