using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class StickyNote : MonoBehaviour
{
	public float rowLimit = 2f;

	[HideInInspector]
	TextMesh textMesh;
	private MeshRenderer textRenderer;
	private SpriteRenderer paperRenderer;

	void Awake()
	{
		paperRenderer = gameObject.GetChild("Paper").GetComponent<SpriteRenderer>();
		textMesh = gameObject.GetChild("Text").GetComponent<TextMesh>();
		textRenderer = gameObject.GetChild("Text").GetComponent<MeshRenderer>();
	}

	void Start()
	{
		setText("What a novel smell you've discovered. Nice job! Have a pack of cigarettes.");
	}

	public string text
	{
		set { this.setText(value); }
	}

	private void setText(string val)
	{
		string[] parts = val.Split(' ');
		string tmp = "";
		textMesh.text = "";
		for (int i = 0; i < parts.Length; i++)
		{
			tmp = textMesh.text;

			textMesh.text += parts[i] + " ";
			if (textRenderer.bounds.extents.x > rowLimit)
			{
				tmp += System.Environment.NewLine;
				tmp += parts[i] + " ";
				textMesh.text = tmp;
			}
		}
	}
}