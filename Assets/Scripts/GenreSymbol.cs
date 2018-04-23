using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class GenreSymbol : MonoBehaviour
{
	public Genre genre = Genre.None;
	private SpriteRenderer sr;
	private DataManager dm;
	private TweenManager tm;

	void Awake()
    {
        dm = DataManager.instance;
        gameObject.Assign(ref sr);
		gameObject.Assign(ref tm);
        SetGenre(genre);
    }

    public void Hide()
	{
		genre = Genre.None;
		sr.sprite = null;
		tm.StopAll();
	}

	public void SetGenre(Genre g)
	{
		if(g == Genre.None)
		{
			Hide();
			return;
		}

		genre = g;
		sr.sprite = dm.genreSprites.Find((GenreSprite a) => { return a.genre == genre; }).symbol;
	}

	public void Blink(bool enabled = true)
	{
		if(enabled)
			tm.Play("blink");
		else tm.StopAll();
	}
}