using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Test : MonoBehaviour
{
	// public Idea[] ideas = new Idea[]
	// {
	// 	new Idea("Things get out of hand", new int[] { 0, 0, 1, 1, 0, 0, 1, 0, 0, 0 }),
	// 		new Idea("A [crazy/silly/funny] romp", new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0 }),
	// 		new Idea("A [damsel/gent] in distress", new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 0, 0 }),
	// 		new Idea("A [weapon/gun/knife] is found", new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 1 }),
	// 		new Idea("A brave front", new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1, 0 }),
	// 		new Idea("A desperate act", new int[] { 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 }),
	// 		new Idea("A dystopian future", new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 }),
	// 		new Idea("A fleeting view of [a man/a woman/someone] ", new int[] { 0, 1, 0, 0, 1, 0, 0, 0, 1, 0 }),
	// 		new Idea("Cross the streams!", new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 }),
	// 		new Idea("Fire up the device!", new int[] { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 }),
	// 		new Idea("The moment we’ve all been waiting for", new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 }),
	// 		new Idea("We’re being followed", new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 }),
	// 		new Idea("A betrayal", new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 }),
	// 		new Idea("A paranormal event", new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 1, 0 }),
	// 		new Idea("A fortuitous encounter", new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0 }),
	// 		new Idea("A stumbling escape", new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1 }),
	// 		new Idea("Deus ex machina", new int[] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1 }),
	// 		new Idea("It’s alive!", new int[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 }),
	// 		new Idea("Don’t make a sound", new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 }),
	// 		new Idea("A city of [wealth/gold/treasures]", new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }),
	// 		new Idea("A disturbing outcome", new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 }),
	// 		new Idea("A lost love", new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }),
	// 		new Idea("A new discovery", new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 }),
	// 		new Idea("A queasy feeling", new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0 }),
	// 		new Idea("It has feelings", new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 }),
	// 		new Idea("A strange device", new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 }),
	// 		new Idea("An act of bravery", new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 }),
	// 		new Idea("An act of deduction", new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 }),
	// 		new Idea("An epic journey", new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 }),
	// 		new Idea("An odd couple", new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 }),
	// 		new Idea("A strange proposition", new int[] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 }),
	// 		new Idea("An unexplained moment", new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 }),
	// 		new Idea("An unusual response", new int[] { 1, 1, 0, 0, 0, 0, 1, 0, 0, 0 }),
	// 		new Idea("Don’t stop until it’s dead", new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }),
	// 		new Idea("Good intentions gone wrong", new int[] { 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 }),
	// 		new Idea("Hand held escape", new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 }),
	// 		new Idea("If it bleeds, we can kill it!", new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 }),
	// 		new Idea("If we make it out of this alive…", new int[] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }),
	// 		new Idea("Imminent doom", new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 }),
	// 		new Idea("Obsessing over a question", new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 }),
	// 		new Idea("Stranger things occur", new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 }),
	// 		new Idea("The meaning of life", new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 }),
	// 		new Idea("What does this button do?", new int[] { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 }),
	// 		new Idea("What have I done?", new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 }),
	// 		new Idea("You can run but you can’t hide", new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 })
	// };

	// Use this for initialization
	void Start()
	{
		// DataManager dm = DataManager.instance;
		// Debug.Log("Genres:" + dm.genres.Join(","));
		// Debug.Log(dm.ideas.Join("\n"));

		// foreach(Idea idea in ideas)
		// {
		// 	List<Genre> genres = new List<Genre>();
		// 	for (int i = 0; i< 10; i++)
		// 	{
		// 		if(idea.genres[i] == 1)
		// 			genres.Add((Genre) i + 1);
		// 	}
			
		// 	Debug.Log("new Idea(\"" + idea.text + "\", new Genre[] { " + genres.Join() +  " }),");
		// }
	}

	// Update is called once per frame
	void Update()
	{

	}
}