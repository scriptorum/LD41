using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Test : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		DataManager dm = DataManager.instance;
		Debug.Log("Genres:" + dm.genres.Join(","));
		Debug.Log(dm.ideas.Join("\n"));
	}

	// Update is called once per frame
	void Update()
	{

	}
}