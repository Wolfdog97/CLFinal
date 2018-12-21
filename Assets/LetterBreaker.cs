using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBreaker : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Letter"))
		{
			Destroy(other.gameObject);
			Debug.Log("Destroying: " + other.name);
		}
	}
}
