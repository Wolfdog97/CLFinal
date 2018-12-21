using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetection : MonoBehaviour
{

	public GameObject player;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Hookable")
		{
			GrapplingHook hook = player.GetComponent<GrapplingHook>();
			hook.hooked = true;
			hook.hookedObject = other.gameObject;
		}
	}
}
