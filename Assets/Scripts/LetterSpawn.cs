using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterSpawn : MonoBehaviour
{
	public List<GameObject> prefabList = new List<GameObject>();

	public void SpawnLetters()
	{
		Debug.Log("Spawning Letters");
		int prefabIndex = Random.Range(0, prefabList.Count);
		Instantiate(prefabList[prefabIndex], transform);
	}
}
