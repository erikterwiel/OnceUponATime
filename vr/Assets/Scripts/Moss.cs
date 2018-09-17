using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Moss : MonoBehaviour
{
	public Dictionary<string, string> CommandMap = new Dictionary<string, string> ();
	public GameObject ground;
	public GameObject sky;

	[RuntimeInitializeOnLoadMethod]
	void Start ()
	{
		
		string dictionaryString = "";

		// Use Prefabs/* 
		CommandMap.Add ("pig", "Pig/pig");
		CommandMap.Add ("brick", "BrickHouse/Prefabs/Baker_house");
		CommandMap.Add ("fire", "FirePlace/Prefabs/FP2015");
		CommandMap.Add ("straw", "StrawHouse/medievalhouse");
		CommandMap.Add ("tree", "Tree/MinecraftTree");
		CommandMap.Add ("wolf", "Wolf/kodi");
		CommandMap.Add ("cauldron", "Cauldron");
		CommandMap.Add ("grass", "green");
		CommandMap.Add ("sky", "blue");

//		if ("Prefabs/" + matSource == "Prefabs/QS/QS-Textures-Grass-v1/Materials/QS-GRASS-2.3.mat") {
//			print ("file match");
//		}
//		Material mat = Resources.Load("Prefabs/" + matSource, typeof(Material)) as Material;


		if (ground.tag == "ground") {
			print ("is ground");
			ground.GetComponentInChildren<Renderer> ().material.color = Color.green;
		} 
		if (sky.tag == "sky") {
			print ("is sky");
			sky.GetComponentInChildren<Renderer> ().material.color = Color.blue;
		} else {
			print ("not ground or sky");
		}

//		foreach (KeyValuePair<string, string> kvp in CommandMap)
//		{
//			//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
//			dictionaryString += string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
//		}
//		print ("dick: " + dictionaryString);
	}

	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

