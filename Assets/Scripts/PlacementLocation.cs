using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementLocation : MonoBehaviour
{

	public GameObject targetProp;
	public PuzzleManager pManager;
	public bool weGood;

	public WordScript wScript;

	public List<GameObject> targetObjects;
	
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckCondition(GameObject propObject)
	{
		if (propObject == targetProp)
		{
			//pManager.LocConditionMet();
			Prop target = targetProp.GetComponent<Prop>();
			Letters letter = targetProp.GetComponent<Letters>();
			if (target.objPlaced)
			{
				wScript.wordSpelled.Add(letter.letterType);
				Debug.Log("adding to the list");
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		CheckCondition(other.gameObject);
	}
}
