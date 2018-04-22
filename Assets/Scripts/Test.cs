using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			StickyNote.Create();
	}
}