using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
	public string tagName = "Ground";
	public bool isGrounded = false;
	public UnityEvent<bool> updateGroundStateEvent;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag(tagName) && collision.contacts[0].normal.z > -0.8f)
		{
			//Grounded
			isGrounded = true;
			updateGroundStateEvent?.Invoke(isGrounded);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (isGrounded && collision.gameObject.CompareTag(tagName))
		{
			//Grounded
			isGrounded = false;
			updateGroundStateEvent?.Invoke(isGrounded);
		}
	}


}
