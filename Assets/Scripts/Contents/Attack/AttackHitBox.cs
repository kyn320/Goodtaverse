using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackHitBox : MonoBehaviour
{
    public UnityEvent<Collision2D, Vector3> collisionEnterEvent;
    public UnityEvent<Collision2D, Vector3> collisionStayEvent;
    public UnityEvent<Collision2D, Vector3> collisionExitEvent;

    public UnityEvent<Collider2D, Vector3> triggerEnterEvent;
    public UnityEvent<Collider2D, Vector3> triggerStayEvent;
    public UnityEvent<Collider2D, Vector3> triggerExitEvent;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterEvent?.Invoke(collision, collision.GetContact(0).point);
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        collisionStayEvent?.Invoke(collision, collision.GetContact(0).point);
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        collisionExitEvent?.Invoke(collision, collision.GetContact(0).point);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent?.Invoke(other, other.ClosestPoint(transform.position));
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        triggerStayEvent?.Invoke(other, other.ClosestPoint(transform.position));
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        triggerExitEvent?.Invoke(other, other.ClosestPoint(transform.position));
    }

}

