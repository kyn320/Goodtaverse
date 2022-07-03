using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAttack : UnitAttack
{
    protected WeaponController weaponController;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetWeapon(WeaponController weaponController) {

        if(this.weaponController != null) { 
            animatorList.Remove(this.weaponController.WeaponAnimator);
        }

        this.weaponController = weaponController;
        animatorList.Add(weaponController.WeaponAnimator);
    }

}
