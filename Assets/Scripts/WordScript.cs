using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;


/*
 * This is all really badly written. Sorry.
 */
public class WordScript : MonoBehaviour
{

	public List<Letters.LetterType> wordSpelled;
	[SerializeField] protected List<Letters.LetterType[]> availableWords;
	
	[SerializeField] protected Letters.LetterType[] yes = new Letters.LetterType[]
	{
		Letters.LetterType.Y,
		Letters.LetterType.E,
		Letters.LetterType.S
	};
	[SerializeField] protected Letters.LetterType[] no = new Letters.LetterType[]
	{
		Letters.LetterType.N,
		Letters.LetterType.O
	};
	[SerializeField] protected Letters.LetterType[] maybe = new Letters.LetterType[]
	{
		Letters.LetterType.M,
		Letters.LetterType.A,
		Letters.LetterType.Y,
		Letters.LetterType.B,
		Letters.LetterType.E,
	};

	public GameObject activateYes;
	public GameObject activateNo;
	public GameObject activateMaybe;
	
	// Use this for initialization
	void Start () {
		availableWords = new List<Letters.LetterType[]>()
		{
			yes, no, maybe
		};
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckingWords();
		
		if (CheckWord(wordSpelled, yes))
		{
			activateYes.SetActive(true);
		}
		if (CheckWord(wordSpelled, no))
		{
			activateNo.SetActive(true);
		}
		if (CheckWord(wordSpelled, maybe))
		{
			activateMaybe.SetActive(true);
		}
	}

	public void CheckingWords()
	{
		CheckWord(wordSpelled, yes);
		Debug.Log("yes " + CheckWord(wordSpelled, yes));
		
		CheckWord(wordSpelled, no);
		Debug.Log("no " + CheckWord(wordSpelled, no));
		
		CheckWord(wordSpelled, maybe);
		Debug.Log("maybe " + CheckWord(wordSpelled, maybe));

		
	}

	public bool CheckWord(List<Letters.LetterType> a, Letters.LetterType[] word)
	{
		if (a == null || word == null)
			return false;

		foreach (Letters.LetterType type in word)
		{
			if (!a.Contains(type)) 
				return false;
		}

		return true;
	}
}
