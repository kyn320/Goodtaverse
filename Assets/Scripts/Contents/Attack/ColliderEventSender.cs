using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventSender : MonoBehaviour
{
    public UnityEvent<Collision2D> collisionEnterEvent;
    public UnityEvent<Collision2D> collisionStayEvent;
    public UnityEvent<Collision2D> collisionExitEvent;

    public UnityEvent<Collider2D> triggerEnterEvent;
    public UnityEvent<Collider2D> triggerStayEvent;
    public UnityEvent<Collider2D> triggerExitEvent;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterEvent?.Invoke(collision);
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        collisionStayEvent?.Invoke(collision);
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        collisionExitEvent?.Invoke(collision);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent?.Invoke(other);
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        triggerStayEvent?.Invoke(other);
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        triggerExitEvent?.Invoke(other);
    }

}
