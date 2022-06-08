using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitController : MonoBehaviour, IDamageable
{
    public float hp;
    public float maxHp;

    public UnityEvent<float, float> updateHpEvent;
    public bool isDeath = false;

    protected virtual void Start()
    {
        hp = maxHp;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        hp -= damage;
        updateHpEvent?.Invoke(hp, maxHp);

        if(hp <= 0)
        {
            isDeath = true;
        }
    }
}
