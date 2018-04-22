using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Spewnity;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static int GENRES = 10;

	public List<GenreSprite> genreSprites = new List<GenreSprite>();
	public Idea[] ideas = new Idea[]
	{
		new Idea("A [WORD] in distress", new Genre[] { Genre.Adventure, Genre.Romance, Genre.Tragedy }),
			new Idea("A [WORD] is found", new Genre[] { Genre.Tragedy, Genre.Mystery, Genre.Suspense }),
			new Idea("A [WORD] romp", new Genre[] { Genre.Action, Genre.Comedy, Genre.Weird }),
			new Idea("A betrayal", new Genre[] { Genre.Action, Genre.Romance, Genre.Mystery }),
			new Idea("A brave front", new Genre[] { Genre.Comedy, Genre.Tragedy, Genre.Mystery }),
			new Idea("A city of [WORD]", new Genre[] { Genre.Action, Genre.Adventure }),
			new Idea("A desperate act", new Genre[] { Genre.Action, Genre.Adventure, Genre.Tragedy }),
			new Idea("A disturbing outcome", new Genre[] { Genre.Horror, Genre.Tragedy }),
			new Idea("A dystopian future", new Genre[] { Genre.Tragedy, Genre.Weird, Genre.Science }),
			new Idea("A fleeting view of [WORD] ", new Genre[] { Genre.Adventure, Genre.Romance, Genre.Mystery }),
			new Idea("A fortuitous encounter", new Genre[] { Genre.Adventure, Genre.Comedy, Genre.Romance }),
			new Idea("A lost love", new Genre[] { Genre.Romance, Genre.Tragedy }),
			new Idea("A new discovery", new Genre[] { Genre.Adventure, Genre.Suspense }),
			new Idea("A paranormal event", new Genre[] { Genre.Horror, Genre.Weird, Genre.Mystery }),
			new Idea("A queasy feeling", new Genre[] { Genre.Horror, Genre.Mystery }),
			new Idea("A strange device", new Genre[] { Genre.Weird, Genre.Science }),
			new Idea("A strange proposition", new Genre[] { Genre.Comedy, Genre.Weird }),
			new Idea("A stumbling escape", new Genre[] { Genre.Adventure, Genre.Comedy, Genre.Suspense }),
			new Idea("An act of bravery", new Genre[] { Genre.Action, Genre.Tragedy }),
			new Idea("An act of deduction", new Genre[] { Genre.Adventure, Genre.Mystery }),
			new Idea("An epic journey", new Genre[] { Genre.Tragedy, Genre.Mystery }),
			new Idea("An odd couple", new Genre[] { Genre.Romance, Genre.Weird }),
			new Idea("An unexplained moment", new Genre[] { Genre.Science, Genre.Mystery }),
			new Idea("An unusual response", new Genre[] { Genre.Action, Genre.Adventure, Genre.Weird }),
			new Idea("Cross the streams!", new Genre[] { Genre.Action, Genre.Weird, Genre.Suspense }),
			new Idea("Deus ex machina", new Genre[] { Genre.Comedy, Genre.Romance, Genre.Suspense }),
			new Idea("Don’t make a sound", new Genre[] { Genre.Comedy, Genre.Mystery, Genre.Suspense }),
			new Idea("Don’t stop until it’s dead", new Genre[] { Genre.Action, Genre.Horror }),
			new Idea("Fire up the device!", new Genre[] { Genre.Action, Genre.Comedy, Genre.Science }),
			new Idea("Good intentions gone wrong", new Genre[] { Genre.Tragedy, Genre.Science }),
			new Idea("Hand held escape", new Genre[] { Genre.Action, Genre.Romance }),
			new Idea("If it bleeds, we can kill it!", new Genre[] { Genre.Adventure, Genre.Horror }),
			new Idea("If we make it out of this alive…", new Genre[] { Genre.Horror, Genre.Romance }),
			new Idea("Imminent doom", new Genre[] { Genre.Tragedy, Genre.Suspense }),
			new Idea("It has feelings", new Genre[] { Genre.Romance, Genre.Science }),
			new Idea("It’s alive!", new Genre[] { Genre.Horror, Genre.Weird, Genre.Science }),
			new Idea("Obsessing over a question", new Genre[] { Genre.Comedy, Genre.Mystery }),
			new Idea("Stranger things occur", new Genre[] { Genre.Weird, Genre.Suspense }),
			new Idea("The meaning of life", new Genre[] { Genre.Comedy, Genre.Science }),
			new Idea("The moment we’ve all been waiting for", new Genre[] { Genre.Romance, Genre.Science, Genre.Suspense }),
			new Idea("Things get out of hand", new Genre[] { Genre.Comedy, Genre.Horror, Genre.Weird }),
			new Idea("We’re being followed", new Genre[] { Genre.Action, Genre.Horror, Genre.Suspense }),
			new Idea("What does this button do?", new Genre[] { Genre.Adventure, Genre.Science }),
			new Idea("What have I done?", new Genre[] { Genre.Horror, Genre.Science }),
			new Idea("You can run but you can’t hide", new Genre[] { Genre.Horror, Genre.Suspense }),

	};

	public Idea GetRandomIdea()
	{
		return ideas.Rnd();
	}

	public static DataManager instance
	{
		get
		{
			DataManager dm = GameObject.Find("/DataManager").GetComponent<DataManager>();
			dm.ThrowIfNull();
			return dm;
		}
	}
}

public class Idea
{
	private const string WordPattern = "[WORD]";
	public string text;
	public Genre[] genres;
	public string[] words;

	public Idea(string text, Genre[] genres)
	{
		MatchEvaluator eval = (Match match) =>
		{
			string value = match.Groups[1].Value;
			this.words = value.Split('/');
			return WordPattern;
		};

		this.text = Regex.Replace(text, @"\[(.*?)\]", eval);
		this.genres = genres;
	}

	public override string ToString()
	{
		return "Idea[" + text +
			" Genres:" + genres.Join(",", "None") +
			" Words:" + words.Join(",", "None") + "]";
	}

	public string GetDescription()
	{
		if (words != null && words.Length > 0)
			return text.Replace(WordPattern, words.Rnd());
		return text;
	}
}

public enum Genre { None, Action, Adventure, Comedy, Horror, Romance, Tragedy, Weird, Science, Mystery, Suspense };

[System.Serializable]
public struct GenreSprite
{
 public Genre genre;
 public Sprite symbol;
}