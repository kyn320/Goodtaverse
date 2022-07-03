using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponController : MonoBehaviour
{
    private Animator weaponAnimator;
    public Animator WeaponAnimator { 
        get { return weaponAnimator; }
    }

    [SerializeField]
    private Collider2D weaponHitBox;

    public Transform weaponPivot;
    public Transform weaponRenderer;

    [SerializeField]
    protected Vector3 lookOffset;

    private Vector3 camLookOffset;

    [SerializeField]
    protected Vector3 lookDirection;

    //공격 히트 시 호출
    public UnityEvent<Collider2D, Vector3> enterHitEvent;

    private void Awake()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    public void LookAtAimPoint(Vector3 lookPosition)
    {
        lookPosition += lookOffset;

        lookDirection = lookPosition - transform.position;
        lookDirection.Normalize();

        var degree = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        weaponPivot.rotation = Quaternion.Euler(0f, 0f, degree);
    }


    public void EnterHit(Collider2D enterCollider, Vector3 hitPoint) {
        enterHitEvent?.Invoke(weaponHitBox, hitPoint);
    }


}
