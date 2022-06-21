using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileController : MonoBehaviour
{
    public ProjectileData projectileData;

    public float damage;

    [SerializeField]
    private string targetTagName;

    public void SetForward(Vector3 forward)
    {
        transform.up = forward;
    }

    public void SetDamage(float damage) { 
        this.damage = damage;
    }

    private void FixedUpdate()
    {
        var moveSpeed = projectileData.statusInfoData.statusDic[StatusType.MoveSpeed].GetAmount();
        transform.position += transform.up * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTagName))
        {
            var damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                var closestPoint = collision.ClosestPoint(collision.transform.position);
                var vfx = ObjectPoolManager.Instance.Get(projectileData.damagedVfx.name);
                vfx.transform.position = closestPoint;
                damageable.OnDamage(damage, closestPoint, collision.transform.position - transform.position);
            }
        }
    }
}
