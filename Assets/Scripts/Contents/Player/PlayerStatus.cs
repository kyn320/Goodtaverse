using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class PlayerStatus : UnitStatus
{
    PlayerStatusSystem playerStatusSystem;

    protected override void Start()
    {
        playerStatusSystem = PlayerStatusSystem.Instance;
        currentStatus = PlayerStatusSystem.Instance.currentStatus;

        //코어 시스템에 바인딩
        playerStatusSystem.updateHpEvent.AddListener(UpdateHpEvent);
        playerStatusSystem.updateMpEvent.AddListener(UpdateMpEvent);
        playerStatusSystem.updateShieldEvent.AddListener(UpdateShieldEvent);
        playerStatusSystem.updateDeathEvent.AddListener(UpdateDeathEvent);
    }

    public override bool OnDamage(float damage)
    {
        CameraController.Instance.AnimateDamaged();
        return playerStatusSystem.AddHP(-damage);
    }

    public void UpdateHpEvent(float curent, float max) {
        updateHpEvent?.Invoke(curent, max); 
    }

    public void UpdateMpEvent(float curent, float max)
    {
        updateMpEvent?.Invoke(curent, max);
    }

    public void UpdateShieldEvent(float curent, float max)
    {
        updateShieldEvent?.Invoke(curent, max);
    }

    public void UpdateDeathEvent(bool isDeath) {
        updateDeathEvent?.Invoke(isDeath);
    }

    private void OnDestroy()
    {
        playerStatusSystem.updateHpEvent.RemoveListener(UpdateHpEvent);
        playerStatusSystem.updateMpEvent.RemoveListener(UpdateMpEvent);
        playerStatusSystem.updateShieldEvent.RemoveListener(UpdateShieldEvent);
        playerStatusSystem.updateDeathEvent.RemoveListener(UpdateDeathEvent);
    }

}
