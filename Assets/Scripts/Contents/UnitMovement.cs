using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public Vector3 direction;
    public float speed;
    public bool useForward = false;
    public bool useVelocity = false;

    private void Awake()
    {
        if (useVelocity)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (useVelocity) {
            var velocity = rigidbody.velocity;
            var normal = direction.normalized;
            velocity.x = speed * normal.x;
            velocity.z = speed * normal.z;
            rigidbody.velocity = velocity;  
        }
        else if (useForward)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    public virtual void UpdateDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public virtual void UpdateDirection(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }

    public virtual void UpdateDirection(Vector3 direction, float speed, bool useForward)
    {
        this.direction = direction;
        this.speed = speed;
        this.useForward = useForward;
    }

}
