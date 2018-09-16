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

	void Start () 
	{
			

	}
	
	void Update () 
	{


		if (toDraw) {
			for (int i = 0; i < 2; i++) {
				showObj (i);
			}

			toDraw = false;
		}
			

		for (int i = 0; i < storyObjects.Count; i++) {
			movObj (i);
		}
	}

	//string prefab, int quantity
	void showObj (string prefab, int quantity) 
	{
		var spawnPosition = new Vector3 (Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
		var spawnRotation = Quaternion.Euler (0f, 0f, 0f);

		obj = new GameObject ("MUX");

		obj = Resources.Load (prefab) as GameObject;

		storyObjects.Add (Instantiate (obj.gameObject, spawnPosition, spawnRotation));
		int[] targetCoord = new int[3];
		targetCoord [0] = 30;
		targetCoord [1] = 10;
		targetCoord [2] = 10;
		targetCoords.Add (targetCoord);
		int targetAngle = 45;
		targetAngles.Add ((targetAngle + 180) % 360);
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
