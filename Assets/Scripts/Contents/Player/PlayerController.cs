using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;

public class PlayerController : UnitController
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private WeaponController weaponController;

    [SerializeField]
    protected Vector3 moveDirection;

    private Vector3 moveInputDirection;
    private Vector3 oldMoveInputDirection;

    [SerializeField]
    protected UnityEvent<Vector3> moveUpdateEvent;

    public int currentCombo = 0;
    public int maxCombo = 3;
    [SerializeField]
    protected UnityEvent<int> comboUpdateEvent;

    [SerializeField]
    protected bool isInput = true;

    public void SetInput(bool isInput)
    {
        this.isInput = isInput;
    }

    void Update()
    {
        if (!isInput)
            return;

        if (Mathf.Abs(oldMoveInputDirection.x) == 0)
        {
            if (Input.GetKeyDown(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveLeft).keyCode))
            {
                moveInputDirection.x = -1;
            }
            if (Input.GetKeyDown(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveRight).keyCode))
            {
                moveInputDirection.x = 1;
            }
        }
        else {
            if (Input.GetKeyUp(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveLeft).keyCode)
                || Input.GetKeyUp(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveRight).keyCode))
            {
                moveInputDirection.x = 0;
            }
        }

        if (Mathf.Abs(oldMoveInputDirection.y) == 0)
        {
            if (Input.GetKeyDown(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveDown).keyCode))
            {
                moveInputDirection.y = -1;
            }
            if (Input.GetKeyDown(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveUp).keyCode))
            {
                moveInputDirection.y = 1;
            }
        }
        else
        {
            if (Input.GetKeyUp(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveDown).keyCode)
                || Input.GetKeyUp(SettingManager.Instance.keySetting.GetKeyBind(KeyType.MoveUp).keyCode))
            {
                moveInputDirection.y = 0;
            }
        }

        if (moveInputDirection != oldMoveInputDirection)
        {
            oldMoveInputDirection = moveInputDirection;
            moveDirection = moveInputDirection;
        }

        //animator.SetBool("Run", moveDirection.sqrMagnitude > 0.5f);
        moveUpdateEvent?.Invoke(moveDirection);
    }


    public override bool OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        var isDeath = base.OnDamage(damage, hitPoint, hitNormal);

        if (isDeath)
        {
            gameObject.SetActive(false);
        }

        return isDeath;
    }

    public void Attack(Vector3 mousePoint)
    {
        ++currentCombo;
        currentCombo %= maxCombo;
        comboUpdateEvent?.Invoke(currentCombo);
    }

}
