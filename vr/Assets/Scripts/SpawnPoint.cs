using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using Tensorflow;

public class SpawnPoint : MonoBehaviour {

	public List<GameObject> storyObjects = new List<GameObject>();
	public List<int[]> targetCoords = new List<int[]>();
	public GameObject obj;
	private bool toDraw = true;
	void Start () {
			
	}

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}
	
	void Update () {


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
	 

		}


		for (int i = 0; i < storyObjects.Count; i++) {
			for (int j = 0 ; j < 3; j++) {
				if (targetCoords[i][j] != storyObjects[i].transform.position[j]) {
					movObj (i,((targetCoords[i][j] - storyObjects[i].transform.position[j]) > 0) ? j : -j, 8);
				}

			}
		}
	}

	void destroyObj (int index) {
		Destroy(storyObjects[index].gameObject);
		storyObjects.RemoveAt (index);
	}

	void movObj (int index, int direction, int magnitude) {

		switch (direction)
		{
		case 2:
			storyObjects [index].transform.Translate(Vector3.up * Time.deltaTime * magnitude);
			break;
		case -2:
			storyObjects [index].transform.Translate(-Vector3.up * Time.deltaTime * magnitude);
			break;
		case -1:
			storyObjects [index].transform.Translate(-Vector3.right * Time.deltaTime * magnitude);
			break;
		case 1:
			storyObjects [index].transform.Translate(Vector3.right * Time.deltaTime * magnitude);
			break;
		case -3:
			storyObjects [index].transform.Translate(-Vector3.forward * Time.deltaTime * magnitude);
			break;
		case 3:
			storyObjects [index].transform.Translate(Vector3.forward * Time.deltaTime * magnitude);
			break;

		default:
			break;
		}
	}


}
