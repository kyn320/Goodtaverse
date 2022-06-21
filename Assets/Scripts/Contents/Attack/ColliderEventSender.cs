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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterEvent?.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionStayEvent?.Invoke(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionExitEvent?.Invoke(collision);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        triggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerExitEvent?.Invoke(other);
    }

}
