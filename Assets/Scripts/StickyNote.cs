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
	private DataManager dm;
	private Idea idea;
	private List<GenreSymbol> syms = new List<GenreSymbol>();

	void Awake()
	{
		dm = DataManager.instance;
		textMesh = gameObject.GetChild("Text").GetComponent<TextMesh>();
		textRenderer = gameObject.GetChild("Text").GetComponent<MeshRenderer>();

		foreach (GenreSymbol gs in gameObject.GetComponentsInChildren<GenreSymbol>())
			syms.Add(gs);
		Debug.Assert(syms.Count == 3);
	}

	void Start()
	{
		Init();
	}

	public void Init()
	{
		idea = dm.GetRandomIdea();
		SetText(idea.GetDescription());
		// TODO Based on difficulty and available symbols, choose to use some or all of them
		for(int index = 0; index < 3; index++)
			UpdateSymbol(index, index < idea.genres.Length ? idea.genres[index] : Genre.None);
	}

	private void UpdateSymbol(int index, Genre g)
	{
		if (index >= idea.genres.Length || g == Genre.None)
			syms[index].Hide();
		else syms[index].SetGenre(g);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			Init();
	}

	public string text
	{
		set { this.SetText(value); }
	}

	private void SetText(string val)
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