using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventDebuger : MonoBehaviour
{

    public void PrintGameObject(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
    }

    public void PrintGameObject(Collision2D collider)
    {
        Debug.Log(collider.gameObject.name);
    }

}
