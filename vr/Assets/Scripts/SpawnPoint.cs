using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour {

	public List<GameObject> storyObjects = new List<GameObject>();
	public List<int[]> targetLocations = new List<int[]>();
	public GameObject obj;
	private bool toDraw = true;
	// Use this for initialization
	void Start () {
			
	}

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}
	
	// Update is called once per frame
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

			}

			toDraw = false;
	 

		}

		for (int i = 0; i < 5; i++) {
			movObj (i, "back", 10);

		}
			

	}

	void destroyObj (int index) {
		Destroy(storyObjects[index].gameObject);
		storyObjects.RemoveAt (index);
	}

	void movObj (int index, string direction, int magnitude) {

		switch (direction)
		{
		case "up":
			storyObjects [index].transform.Translate(Vector3.up * Time.deltaTime * magnitude);
			break;
		case "down":
			storyObjects [index].transform.Translate(-Vector3.up * Time.deltaTime * magnitude);
			break;
		case "left":
			storyObjects [index].transform.Translate(-Vector3.right * Time.deltaTime * magnitude);
			break;
		case "right":
			storyObjects [index].transform.Translate(Vector3.right * Time.deltaTime * magnitude);
			break;
		case "back":
			storyObjects [index].transform.Translate(-Vector3.forward * Time.deltaTime * magnitude);
			break;
		case "forward":
			storyObjects [index].transform.Translate(Vector3.forward * Time.deltaTime * magnitude);
			break;

		default:
			break;
		}
	}


}
