using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
	public GameObject hook;
	public GameObject hookHolder;

	public float hookTravelSpeed;
	public float playerTravelSpeed;

	public float breakDistance = 1;

	public static bool fired;
	public bool hooked;
	public bool grounded;
	
	public GameObject hookedObject;

	public float maxDistance;
	protected float _currentDistance;

	void Update()
	{
		//firing hook
		if (Input.GetMouseButtonDown(0) && fired == false)
		{
			fired = true;
		}

		if (Input.GetMouseButtonDown(1) && fired)
		{
			ReturnHook();
		}

		if (fired)
		{
			LineRenderer rope = hook.GetComponent<LineRenderer>();
			rope.positionCount = 2;
			rope.SetPosition(0, hookHolder.transform.position);
			rope.SetPosition(1, hook.transform.position);
		}

		if (fired && !hooked)
		{
			hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
			_currentDistance = Vector3.Distance(transform.position, hook.transform.position);

			if (_currentDistance >= maxDistance)
			{
				ReturnHook();
			}
		}

		if (hooked && fired)
		{
			hook.transform.parent = hookedObject.transform;
			transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
			float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

			GetComponent<Rigidbody>().useGravity = false;

			if (distanceToHook < breakDistance)
			{
				if (!grounded)
				{
					transform.Translate(Vector3.forward * Time.deltaTime * 10f);
					transform.Translate(Vector3.up * Time.deltaTime * 18f);
				}

				StartCoroutine("Climb");
			}
		}
		else
		{
			hook.transform.parent = hookHolder.transform;
			GetComponent<Rigidbody>().useGravity = true;
		}
		
		CheckIfGrounded();
	}

	IEnumerator Climb()
	{
		yield return new WaitForSeconds(0.1f);
		ReturnHook();
	}

	void ReturnHook()
	{
		hook.transform.rotation = hookHolder.transform.rotation;
		hook.transform.position = hookHolder.transform.position;
		fired = false;
		hooked = false;
		
		LineRenderer rope = hook.GetComponent<LineRenderer>();
		rope.positionCount = 0;
	}

	void CheckIfGrounded()
	{
		RaycastHit hit;
		float distance = 1f;
		
		Vector3 dir = Vector3.down;

		if (Physics.Raycast(transform.position, dir, out hit, distance))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
	}
}
