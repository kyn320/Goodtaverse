using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJump : MonoBehaviour
{
	public Vector3 direction;
	public float power;
	
	public GameObject jumpVFX;

	public new Rigidbody rigidbody;

	private void Awake()
	{
		if (rigidbody == null)
			rigidbody = GetComponent<Rigidbody>();
	}

	public virtual void Jump()
	{
		var normDirection = direction.normalized;
		var powerDirection = rigidbody.velocity;

		if (normDirection.x > 0)
		{
			powerDirection.x = normDirection.x;
		}

		if (normDirection.y > 0)
		{
			powerDirection.y = normDirection.y;
		}

		if (normDirection.z > 0)
		{
			powerDirection.z = normDirection.z;
		}

		rigidbody.velocity = powerDirection * power;

		//var vfx = ObjectPoolManager.Instance.Get(jumpVFX.name);
		//vfx.transform.position = transform.position;
	}

}
