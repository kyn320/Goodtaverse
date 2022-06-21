using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponPivot;
    public Transform weaponRenderer;

    [SerializeField]
    protected Vector3 lookOffset;

    private Vector3 camLookOffset;

    [SerializeField]
    protected Vector3 lookDirection;


    public void LookAtAimPoint(Vector3 lookPosition)
    {
        lookPosition += lookOffset;

        lookDirection = lookPosition - transform.position;
        lookDirection.Normalize();

        var degree = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        weaponPivot.rotation = Quaternion.Euler(0f, 0f, degree);
        //weaponRenderer.localRotation = Quaternion.Euler(-lookDirection.x  *  45f, lookDirection.y * 45f, 0f);
    }

    public void Attack()
    {

    }

}
