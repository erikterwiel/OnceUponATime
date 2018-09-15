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
			obj = Resources.Load("Prefabs/FirePlace/FP2015") as GameObject;
			Debug.Log (obj.name);
			storyObjects.Add (obj);
			Instantiate(obj, spawnPosition, spawnRotation);
		}
		//StartCoroutine (stall (5));

		for (int i = 0; i < 5; i++) {
			storyObjects.RemoveAt (i);
		}
			
	}

	IEnumerator stall (int tiem) {
		yield return new WaitForSeconds(tiem);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
