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
	private bool draggable = true;
	private Vector3 screenSpace, offset;
	public GameObject stickyNotePrefab;
	private static float stickyDepth = 0f;

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
		for (int index = 0; index < 3; index++)
			UpdateSymbol(index, index < idea.genres.Length ? idea.genres[index] : Genre.None);
	}

	void OnMouseDrag()
	{
		//keep track of the mouse position
		Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

		//convert the screen mouse position to world point and adjust with offset
		var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

		//update the position of the object in the world
		transform.position = curPosition;
	}

	void OnMouseDown()
	{
        UpdateDepth();

		//translate the cubes position from the world to Screen Point
		screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
        offset = transform.position - Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
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

	public static void Create()
	{
        DataManager dm = DataManager.instance;
        GameObject go = GameObject.Instantiate(dm.stickyNotePrefab);
		go.transform.parent = dm.levelContainer;
		stickyDepth -= 0.00001f;
		go.transform.position = new Vector3(Random.Range(1f, 6f), Random.Range(-4, 5), stickyDepth);
		go.transform.Rotate(0, 0, Random.Range(-15, 15));
	}

	public float UpdateDepth()
	{
		stickyDepth -= 0.00001f;
		transform.position = new Vector3(transform.position.x, transform.position.y, stickyDepth);
		return stickyDepth;
	}
}