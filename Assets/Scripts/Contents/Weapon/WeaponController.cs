using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Collider2D weaponHitBox;

    public Transform weaponPivot;
    public Transform weaponRenderer;

    [SerializeField]
    protected Vector3 lookOffset;

    private Vector3 camLookOffset;

    [SerializeField]
    protected Vector3 lookDirection;

    //���� ��Ʈ �� ȣ��
    public UnityEvent<Collider2D,Collider2D> enterHitColliderEvent;

    public void LookAtAimPoint(Vector3 lookPosition)
    {
        lookPosition += lookOffset;

        lookDirection = lookPosition - transform.position;
        lookDirection.Normalize();

        var degree = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        weaponPivot.rotation = Quaternion.Euler(0f, 0f, degree);
        //weaponRenderer.localRotation = Quaternion.Euler(-lookDirection.x  *  45f, lookDirection.y * 45f, 0f);
    }

    //Delay : ��Ʈ�ڽ��� ������ ���� ������� ����
    public void EnterHit(Collider2D enterCollider) {
        enterHitColliderEvent?.Invoke(weaponHitBox, enterCollider);
    }


}
