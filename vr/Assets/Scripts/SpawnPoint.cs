using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour {

	public List<GameObject> storyObjects = new List<GameObject>();
	public GameObject obj;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			var spawnPosition = new Vector3(1f + i, 1f + i, 1f + i);
			var spawnRotation = Quaternion.Euler(0f, 0f, 0f);

			obj = new GameObject ("MUX");

			if (i % 2 == 0) {
				obj = Resources.Load ("Prefabs/FirePlace/FP2015") as GameObject;
			} else {
				obj = Resources.Load ("Prefabs/Wolf/kodi") as GameObject;
			}

			Debug.Log (obj.name);
			storyObjects.Add (Instantiate(obj.gameObject, spawnPosition, spawnRotation));

		}
		//StartCoroutine (stall (5));

		for (int i = 0; i < 5; i++) {
			exitObj (i,"up");
		}	
			
	}

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void deleteObj (int index) {
		Destroy(storyObjects[index].gameObject);
		storyObjects.RemoveAt (index);
	}

	void exitObj (int index, string direction) {

		Rigidbody rb = storyObjects[index].AddComponent<Rigidbody>();
		
		switch (direction)
		{
		case "up":
			//Vector3 moss = new Vector3 (10,10,10);
			rb.AddForce(transform.forward);
			break;


		default:
			break;
		}
	}


}
