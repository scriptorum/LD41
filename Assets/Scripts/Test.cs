using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
	public GameObject stickyNotePrefab;
	private float z = 0;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			CreateSticky();
	}

	public void CreateSticky()
	{
		GameObject go = GameObject.Instantiate(stickyNotePrefab);
		go.transform.parent = transform;
		go.transform.position = new Vector3(Random.Range(1f, 6f), Random.Range(-4, 5), z);
		go.transform.Rotate(0, 0, Random.Range(-15, 15));
		z -= 0.00001f;
	}

	public void UpdateZ()
	{
		// go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, z);
		// z -= 0.00001f;
	}
}