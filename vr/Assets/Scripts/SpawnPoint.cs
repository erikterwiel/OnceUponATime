using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject obj = new GameObject();
	// Use this for initialization
	void Start () {
		var spawnPosition = new Vector3(1f, 1f, 1f);
		var spawnRotation = Quaternion.Euler(0f, 0f, 0f);
		obj = Resources.Load("Prefabs/Player") as GameObject;
		Debug.Log (obj.name);
		Instantiate(obj, spawnPosition, spawnRotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
