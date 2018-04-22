using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class GenreSymbol : MonoBehaviour
{
	public Genre selectedGenre = Genre.None;
	private SpriteRenderer sr;
	private DataManager dm;

	void Awake()
	{
		gameObject.Assign(ref sr);
		dm = DataManager.instance;
	}

	public void Hide()
	{
		selectedGenre = Genre.None;
		sr.sprite = null;
	}

	public void SetGenre(Genre g)
	{
		if(g == Genre.None)
		{
			Hide();
			return;
		}

		selectedGenre = g;
		sr.sprite = dm.genreSprites.Find((GenreSprite a) => { return a.genre == selectedGenre; }).symbol;
	}
}