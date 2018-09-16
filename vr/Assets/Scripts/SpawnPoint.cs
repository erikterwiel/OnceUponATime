using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using Tensorflow;



public class SpawnPoint : MonoBehaviour {

	public Dictionary<string, string> CommandMap = new Dictionary <string, string> ();

	public List <GameObject> storyObjects = new List<GameObject>();
	public List <int[]> targetCoords = new List <int[]>();
	public List <int> targetAngles = new List <int>();
	public GameObject obj;
	private bool toDraw = true;
	static int countObj = 0;

	void Start () 
	{
			

	}
	public static string nameOfObject;
	void Update () 
	{


		/*if (toDraw) {
			for (int i = 0; i < 2; i++) {
				
				show (nameOfObject, i);
			}

			toDraw = false;
		}
			

		for (int i = 0; i < storyObjects.Count; i++) {
			movObj (i);
		}*/
	}

	public void show (string prefab, int amount) {
		++countObj;			
		var spawnPosition = new Vector3 (0 + countObj * 5, 0, 0);
		var spawnRotation = Quaternion.Euler (0f, 0f, 0f);
		obj = new GameObject ("MUX");

//		obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
//		prefab = "Wolf/kodi";
		obj = Resources.Load ("Prefabs/" + prefab) as GameObject;
		GameObject newObject = Instantiate(obj.gameObject, spawnPosition, spawnRotation) as GameObject;  // instatiate the object			

		switch (prefab) {
			case "Pig/pig":
				newObject.gameObject.transform.Rotate(270f, 90f, 180f);
				newObject.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
				newObject.gameObject.transform.GetChild(0).localScale -= new Vector3(0.5f, 0.5f, 0.5f);
				break;
			case "BrickHouse/Prefabs/Baker_house":
				newObject.gameObject.transform.Rotate(270f, 90f, 180f);
				newObject.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				break;
			case "FirePlace/FP2015":
				newObject.gameObject.transform.Rotate(0f, 90f, 0f);
				newObject.gameObject.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
				break;
			case "Tree/MinecraftTree":
				newObject.gameObject.transform.Rotate (0f, 5f, 0f);
				newObject.gameObject.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
				newObject.gameObject.transform.position = new Vector3 (5f, 5.5f, 0f);
				break;
			case "Wolf/kodi":
				break;
			case "Cauldron":
				break;
			case "green":
				break;
			case "blue":
				break;
		
		}




		storyObjects.Add (newObject/*Instantiate (obj.gameObject, spawnPosition, spawnRotation)*/);
		int[] targetCoord = new int[3];
		targetCoord [0] = 30;
		targetCoord [1] = 10;
		targetCoord [2] = 10;
		targetCoords.Add (targetCoord);
		int targetAngle = 45;
		targetAngles.Add ((targetAngle + 180) % 360);	
	}
		
	public void hide (int index) {
	
	}

	public void move (int fromIndex, int toIndex) {
	
	}

	void hideObj (int id) 
	{
		GameObject toDie = storyObjects[id];
		storyObjects.RemoveAt (id);

		Vector3 targetVector = new Vector3 (toDie.transform.position[0], -100, toDie.transform.position[2]);
		toDie.transform.Translate(Time.deltaTime * (targetVector - toDie.transform.position));
		Destroy(toDie);
	}

	void movObj (int id) 
	{
		Vector3 targetVector = new Vector3 (targetCoords [id][0], targetCoords [id][1], targetCoords [id][2]);
		storyObjects[id].transform.LookAt(storyObjects[0].transform);
		storyObjects[id].transform.Translate(Time.deltaTime * (targetVector - storyObjects[id].transform.position));
	}

//	bool OnCollisionEnter (Collision col)
//	{
//		print ("LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
//	}

}