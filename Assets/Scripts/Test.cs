using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		DataManager dm = DataManager.instance;
		Debug.Log("Genres:" + dm.genres);
		foreach (Idea idea in dm.ideas)
			Debug.Log(idea);
	}

	// Update is called once per frame
	void Update()	
	{

	}
}