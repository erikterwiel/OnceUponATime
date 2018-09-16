//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class SpawnPoint : MonoBehaviour {
//
//	public List<GameObject> storyObjects = new List<GameObject>();
//	public GameObject obj = new GameObject();
//	// Use this for initialization
//	void Start () {
//		Invoke ("SpawnObj", 2);
//		Invoke ("SpawnObj", 2);
//		Invoke ("SpawnObj", 2);
//		Invoke ("SpawnObj", 2);
//	}
//
//	void SpawnObj(){
//		for (int i = 0; i < 5; i++) {
//			var spawnPosition = new Vector3(1f + i, 1f + i, 1f + i);
//			var spawnRotation = Quaternion.Euler(0f, 0f, 0f);
//			obj = new GameObject ("MUX");
//			obj = Resources.Load("Prefabs/FirePlace/FP2015") as GameObject;
//			storyObjects.Add (obj);
//			print (storyObjects);
//			Instantiate(obj, spawnPosition, spawnRotation);
//		}	
//		//		StartCoroutine (stall (5));	
//	}
//
////	void DeleteObj() {
////		for (int i = 0; i < 5; i++) {
////			DestroyImmediate(storyObjects[i] , true);
////			//			storyObjects.RemoveAt (i);
////			print("deleting");
////		}
////	}
//	// Update is called once per frame
//	void Update () {
//
//	}
//	IEnumerator stall (int tiem) {
//		yield return new WaitForSeconds(tiem);
//	}
//}

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

	void Start () {
			
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

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}


	
	void Update () {


		if (toDraw) {
			for (int i = 0; i < 2; i++) {
				var spawnPosition = new Vector3 (1f + i, 1f + i, 1f + i);
				var spawnRotation = Quaternion.Euler (0f, 0f, 0f);

				obj = new GameObject ("MUX");

				if (i == 0) {
					obj = Resources.Load ("Prefabs/FirePlace/FP2015") as GameObject;
				} else {
					obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
				}

				storyObjects.Add (Instantiate (obj.gameObject, spawnPosition, spawnRotation));
				int[] targetCoord = new int[3];
				targetCoord [0] = 20;
				targetCoord [1] = 20;
				targetCoord [2] = 20;
				targetCoords.Add (targetCoord);
				int targetAngle = 45;
				targetAngles.Add ((targetAngle += 180) % 360);

			}

			toDraw = false;
	 

		}


		for (int i = 0; i < storyObjects.Count; i++) {
			for (int j = 0 ; j < 3; j++) {
				if (targetCoords[i][j] != (int) Math.Round(storyObjects[i].transform.position[j])) {
					movObj (i,((targetCoords[i][j] - 
						(int) Math.Round(storyObjects[i].transform.position[j])) > 0) ? j+1 : -j-1, 8);
				}

			}
			if ((int) Math.Round (storyObjects [i].transform.rotation.eulerAngles [1]) != targetAngles[i]) {
				rotObj (i,((targetAngles[i] - (int) Math.Round(storyObjects [i].transform.rotation.eulerAngles [1])) > 0) ? -10: 10);
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

	void rotObj (int index, int deltaAngle) {
		storyObjects [index].transform.Rotate (Vector3.up * Time.deltaTime * deltaAngle);
		print ("MOSS >>>>>>>>>>>> " + storyObjects [1].transform.rotation.eulerAngles [1]);
	}


}
