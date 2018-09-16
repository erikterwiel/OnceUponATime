using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using Tensorflow;



public class SpawnPoint : MonoBehaviour {

<<<<<<< HEAD
<<<<<<< HEAD
	public Dictionary<string, string> CommandMap = new Dictionary <string, string> ();

	public List <GameObject> storyObjects = new List<GameObject>();
	public List <int[]> targetCoords = new List <int[]>();
	public List <int> targetAngles = new List <int>();
=======
=======

>>>>>>> b7a2713... fixed Network Manager
	public List<GameObject> storyObjects = new List<GameObject>();
	public List<int[]> targetCoords = new List<int[]>();
>>>>>>> 25d3f5a... fixed merge conflicts
	public GameObject obj;
	private bool toDraw = true;
	public string commandShit = "";



<<<<<<< HEAD
	void Start () 
	{
			
=======

	void Start () {	
				
>>>>>>> b7a2713... fixed Network Manager
		for (int i = 0; i < 5; i++) {
			var spawnPosition = new Vector3(1f + i, 1f + i, 1f + i);
			var spawnRotation = Quaternion.Euler(0f, 0f, 0f);
			obj = new GameObject ("MUX");
			obj = Resources.Load("Prefabs/FirePlace/FP2015") as GameObject;
			storyObjects.Add (obj);
			Instantiate(obj, spawnPosition, spawnRotation);
			print (obj);
		}
		//StartCoroutine (stall (5));

		for (int i = 0; i < 5; i++) {
			storyObjects.RemoveAt (i);
		}

	}
<<<<<<< HEAD
	
	void Update () 
	{


		if (toDraw) {
			for (int i = 0; i < 5; i++) {
				var spawnPosition = new Vector3 (1f + i, 1f + i, 1f + i);
				var spawnRotation = Quaternion.Euler (0f, 0f, 0f);

				obj = new GameObject ("MUX");

				if (i % 2 == 0) {
					obj = Resources.Load ("Prefabs/FirePlace/FP2015") as GameObject;
				} else {
					obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
				}

				Debug.Log (obj.name);
				storyObjects.Add (Instantiate (obj.gameObject, spawnPosition, spawnRotation));
				int[] mux = new int[3];
				mux [0] = 50;
				mux [1] = 50;
				mux [2] = 50;
				targetCoords.Add (mux);

			}

			toDraw = false;
	 

<<<<<<< HEAD
		for (int i = 0; i < storyObjects.Count; i++) {
			movObj (i);
		}
	}

	//string prefab, int quantity
	void showObj (string prefab, int quantity) 
	{
		var spawnPosition = new Vector3 (Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
		var spawnRotation = Quaternion.Euler (0f, 0f, 0f);
=======
		}
>>>>>>> 25d3f5a... fixed merge conflicts


		for (int i = 0; i < storyObjects.Count; i++) {
			for (int j = 0 ; j < 3; j++) {
				if (targetCoords[i][j] != storyObjects[i].transform.position[j]) {
					movObj (i,((targetCoords[i][j] - storyObjects[i].transform.position[j]) > 0) ? j : -j, 8);
				}

			}
		}
	}

<<<<<<< HEAD
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
=======
	void destroyObj (int index) {
		Destroy(storyObjects[index].gameObject);
		storyObjects.RemoveAt (index);
=======

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}
		
	public void show (string fileName, int amount) {
	
	}

<<<<<<< HEAD
	void hide (int index) {
>>>>>>> b7a2713... fixed Network Manager
=======
	public void hide (int index) {
>>>>>>> cbdf8ab... Did some shit idk
	}

	public void move (int fromIndex, int toIndex) {
	}
	
//	void Update () {
//
//
//		if (toDraw) {
//			for (int i = 0; i < 5; i++) {
//				var spawnPosition = new Vector3 (1f + i, 1f + i, 1f + i);
//				var spawnRotation = Quaternion.Euler (0f, 0f, 0f);
//
//				obj = new GameObject ("MUX");
//
//				if (i % 2 == 0) {
//					obj = Resources.Load ("Prefabs/FirePlace/FP2015") as GameObject;
//				} else {
//					obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
//				}
//
//				Debug.Log (obj.name);
//				storyObjects.Add (Instantiate (obj.gameObject, spawnPosition, spawnRotation));
//				int[] mux = new int[3];
//				mux [0] = 50;
//				mux [1] = 50;
//				mux [2] = 50;
//				targetCoords.Add (mux);
//
//			}
//
//			toDraw = false;
//	 
//
//		}
//
//
//		for (int i = 0; i < storyObjects.Count; i++) {
//			for (int j = 0 ; j < 3; j++) {
//				if (targetCoords[i][j] != storyObjects[i].transform.position[j]) {
//					movObj (i,((targetCoords[i][j] - storyObjects[i].transform.position[j]) > 0) ? j : -j, 8);
//				}
//
//			}
//		}
//	}
//
//	void destroyObj (int index) {
//		Destroy(storyObjects[index].gameObject);
//		storyObjects.RemoveAt (index);
//	}
//
//	void movObj (int index, int direction, int magnitude) {
//
//		switch (direction)
//		{
//		case 2:
//			storyObjects [index].transform.Translate(Vector3.up * Time.deltaTime * magnitude);
//			break;
//		case -2:
//			storyObjects [index].transform.Translate(-Vector3.up * Time.deltaTime * magnitude);
//			break;
//		case -1:
//			storyObjects [index].transform.Translate(-Vector3.right * Time.deltaTime * magnitude);
//			break;
//		case 1:
//			storyObjects [index].transform.Translate(Vector3.right * Time.deltaTime * magnitude);
//			break;
//		case -3:
//			storyObjects [index].transform.Translate(-Vector3.forward * Time.deltaTime * magnitude);
//			break;
//		case 3:
//			storyObjects [index].transform.Translate(Vector3.forward * Time.deltaTime * magnitude);
//			break;
//
//		default:
//			break;
//		}
//	}

>>>>>>> 25d3f5a... fixed merge conflicts

}
