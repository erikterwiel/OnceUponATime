using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using Tensorflow;



public class SpawnPoint : MonoBehaviour {

	public Dictionary<string, string> CommandMap = new Dictionary<string, string> ();

//	Renderer rend;
	// Use this for initialization



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
			//storyObjects[i].transform.rotation = new Quaternion(0, targetAngles[i], 0, 0);
			storyObjects[i].transform.LookAt(storyObjects[2].transform);
			storyObjects[i].transform.Translate(Time.deltaTime * (targetVector - storyObjects[i].transform.position));
			/*for (int j = 0 ; j < 3; j++) {
				if (Math.Abs (targetCoords [i] [j] - (int)Math.Round (storyObjects [i].transform.position [j])) >= 1) {
					if (j == 0) {
						print ("dfkjhgjhfdoskljl" + (int) Math.Round (storyObjects [i].transform.position [j]));
					
					}
					//print ("dfkjhgjhfdoskljl" + (int) Math.Round (storyObjects [i].transform.position [j]));
					movObj (i, ((targetCoords [i] [j] -
						(int) Math.Round (storyObjects [i].transform.position [j])) > 0) ? j + 1 : -j - 1, 8);
				} 

			}

			if (Math.Abs((int) Math.Round (storyObjects [i].transform.rotation.eulerAngles [1]) - targetAngles[i]) >= 1) {
				rotObj (i,((targetAngles[i] - (int) Math.Round(storyObjects [i].
					transform.rotation.eulerAngles [1])) > 0) ? 35: -35);
			}*/

		}
	}
	//string prefab, int quantity
	void showObj (int index) {
		var spawnPosition = new Vector3 (1f + index, 1f + index, 1f + index);
		var spawnRotation = Quaternion.Euler (0f, 0f, 0f);

		obj = new GameObject ("MUX");

		if (index == 0) {
			obj = Resources.Load ("Prefabs/FirePlace/FP2015") as GameObject;
		} else {
			obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
		}

		storyObjects.Add (Instantiate (obj.gameObject, spawnPosition, spawnRotation));
		int[] targetCoord = new int[3];
		targetCoord [0] = 30;
		targetCoord [1] = 10;
		targetCoord [2] = 10;
		targetCoords.Add (targetCoord);
		int targetAngle = 45;
		targetAngles.Add ((targetAngle + 180) % 360);
	}

	void hideObj (int index) {
		Destroy(storyObjects[index].gameObject);
		storyObjects.RemoveAt (index);
	}

	void movObj (int index, int direction, int magnitude) {

		switch (direction)
		{
		case 2:
			storyObjects [index].transform.Translate(0,Time.deltaTime * magnitude,0);
			break;
		case -2:
			storyObjects [index].transform.Translate(0,-Time.deltaTime * magnitude,0);
			break;
		case -1:
			storyObjects [index].transform.Translate(-Time.deltaTime * magnitude,0,0);
			break;
		case 1:
			storyObjects [index].transform.Translate(Time.deltaTime * magnitude,0,0);
			break;
		case -3:
			storyObjects [index].transform.Translate(0,0,-Time.deltaTime * magnitude);
			break;
		case 3:
			storyObjects [index].transform.Translate(0,0,Time.deltaTime * magnitude);
			break;
		default:
			break;
		}
	}

	void rotObj (int index, int deltaAngle) {
		storyObjects [index].transform.Rotate (0, Time.deltaTime * deltaAngle, 0);
	}
		


}
