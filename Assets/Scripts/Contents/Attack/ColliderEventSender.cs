using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class ColliderEventSender : MonoBehaviour
{
    public UnityEvent<Collision> collisionEnterEvent;
    public UnityEvent<Collision> collisionStayEvent;
    public UnityEvent<Collision> collisionExitEvent;

    public UnityEvent<Collider> triggerEnterEvent;
    public UnityEvent<Collider> triggerStayEvent;
    public UnityEvent<Collider> triggerExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent?.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        collisionStayEvent?.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionExitEvent?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        triggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke(other);
    }

}
