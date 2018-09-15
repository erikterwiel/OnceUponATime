using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject objPrefab = Resources.Load("Assets/Prefabs/Bullet.prefab") as GameObject;
		GameObject obj = Instantiate(objPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
