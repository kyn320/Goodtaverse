using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTargetMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 10.0f;
    private Vector3 point;

    void Start()
    {
        point = target.position;
    }

    void Update()
    {
        transform.LookAt(point);
        transform.RotateAround(point, Vector3.up, Time.deltaTime * speed);
    }
}
