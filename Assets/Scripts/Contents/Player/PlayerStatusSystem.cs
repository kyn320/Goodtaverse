using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class PlayerStatusSystem : Singleton<PlayerStatusSystem>
{
    [SerializeField]
    private StatusInfoData originStatusData;
    public StatusInfo currentStatus;
    public bool isDeath = false;

    public UnityEvent<float, float> updateHpEvent;
    public UnityEvent<float, float> updateMpEvent;
    public UnityEvent<float, float> updateShieldEvent;

    public UnityEvent<bool> updateDeathEvent;

    protected override void Awake()
    {
        base.Awake();

        if (originStatusData != null)
        {
            currentStatus.Copy(originStatusData.statusDic);
        }
    }

    public bool AddHP(float amount)
    {
        var hpElement = currentStatus.GetElement(StatusType.HP);
        var maxHPElement = currentStatus.GetElement(StatusType.MaxHP);

        hpElement.AddAmount(amount);

        updateHpEvent?.Invoke(hpElement.GetAmount(), maxHPElement.GetAmount());

        if (hpElement.GetAmount() <= 0)
        {
            isDeath = true;
            updateDeathEvent?.Invoke(isDeath);
        }

        return isDeath;
    }

    public void AddMP(float amount)
    {
        var mpElement = currentStatus.GetElement(StatusType.MP);
        var maxMPElement = currentStatus.GetElement(StatusType.MaxMP);

        mpElement.AddAmount(amount);

        updateHpEvent?.Invoke(mpElement.GetAmount(), maxMPElement.GetAmount());
    }

    public void AddShield(float amount)
    {
        var shieldElement = currentStatus.GetElement(StatusType.Shield);
        var maxShieldElement = currentStatus.GetElement(StatusType.MaxShield);

        shieldElement.AddAmount(amount);

        updateHpEvent?.Invoke(shieldElement.GetAmount(), maxShieldElement.GetAmount());
    }



}
