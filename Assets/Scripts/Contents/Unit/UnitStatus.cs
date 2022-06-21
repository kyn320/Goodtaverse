using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class UnitStatus : SerializedMonoBehaviour
{
    [SerializeField]
    protected StatusInfoData originStatusData;
    [SerializeField]
    public StatusInfo currentStatus;

    public bool isDeath = false;
    public UnityEvent<float, float> updateHpEvent;
    public UnityEvent<float, float> updateMpEvent;
    public UnityEvent<float, float> updateShieldEvent;

    public UnityEvent<bool> updateDeathEvent;

    protected virtual void Start()
    {
        if (originStatusData != null)
        {
            currentStatus.Copy(originStatusData.statusDic);
        }
    }

    public virtual bool OnDamage(float damage)
    {
        var hpElement = currentStatus.GetElement(StatusType.HP);
        var maxHPElement = currentStatus.GetElement(StatusType.MaxHP);

        hpElement.AddAmount(-damage);

        updateHpEvent?.Invoke(hpElement.GetAmount(), maxHPElement.GetAmount());

        if (hpElement.GetAmount() <= 0)
        {
            isDeath = true;
            updateDeathEvent?.Invoke(isDeath);
        }

        return isDeath;
    }

}
