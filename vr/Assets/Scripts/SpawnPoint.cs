using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using Tensorflow;



public class SpawnPoint : MonoBehaviour {

	public Dictionary<string, string> CommandMap = new Dictionary<string, string> ();

	public List<GameObject> storyObjects = new List<GameObject>();
	public List<int[]> targetCoords = new List<int[]>();
	public List<int> targetAngles = new List<int>();
	public GameObject obj;
	private bool toDraw = true;

	void Start () {
			

	}

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}


	
	void Update () {


		if (toDraw) {
			for (int i = 0; i < 2; i++) {
				showObj (i);
			}

			toDraw = false;
		}
			

		for (int i = 0; i < storyObjects.Count; i++) {
			Vector3 targetVector = new Vector3 (targetCoords [i][0], targetCoords [i][1], targetCoords [i][2]);
			storyObjects[i].transform.LookAt(storyObjects[0].transform);
			storyObjects[i].transform.Translate(Time.deltaTime * (targetVector - storyObjects[i].transform.position));
		}
	}

	//string prefab, int quantity
	void showObj (string prefab, int quantity) {
		var spawnPosition = new Vector3 (1f, 1f, 1f);
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

	void hideObj (int id) {
		Destroy(storyObjects[id].gameObject);
		storyObjects.RemoveAt (id);
	}

	void movObj (int id, int direction, int magnitude) {

		switch (direction)
		{
		case 2:
			storyObjects [id].transform.Translate(0,Time.deltaTime * magnitude,0);
			break;
		case -2:
			storyObjects [id].transform.Translate(0,-Time.deltaTime * magnitude,0);
			break;
		case -1:
			storyObjects [id].transform.Translate(-Time.deltaTime * magnitude,0,0);
			break;
		case 1:
			storyObjects [id].transform.Translate(Time.deltaTime * magnitude,0,0);
			break;
		case -3:
			storyObjects [id].transform.Translate(0,0,-Time.deltaTime * magnitude);
			break;
		case 3:
			storyObjects [id].transform.Translate(0,0,Time.deltaTime * magnitude);
			break;
		default:
			break;
		}
	}

	void rotObj (int index, int deltaAngle) {
		storyObjects [index].transform.Rotate (0, Time.deltaTime * deltaAngle, 0);
	}
		


}
