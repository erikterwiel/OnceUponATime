using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public GameObject spawnPoint;
	public int numberOfEnemies;
	[HideInInspector]
	public List<SpawnPoint> enemySpawnPoints;

	// Use this for initialization
	void Start () {

		var spawnPosition = new Vector3(1f, 1f, 1f);
		var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f);
		GameObject objPrefab = Resources.Load("Prefabs/Bullet.prefab") as GameObject;
		GameObject obj = Instantiate(objPrefab, spawnPosition, spawnRotation) as GameObject;
	}

	public void SpawnEnemies(NetworkManager.EnemiesJSON enemiesJSON)
	{
		foreach (NetworkManager.UserJSON enemyJSON in enemiesJSON.enemies)
		{
			if (enemyJSON.health <= 0)
			{
				continue;
			} 
			Vector3 position = new Vector3(enemyJSON.position[0], enemyJSON.position[1], enemyJSON.position[2]);
			Quaternion rotation = Quaternion.Euler(enemyJSON.rotation[0], enemyJSON.rotation[1], enemyJSON.rotation[2]);
			GameObject newEnemy = Instantiate(enemy, position, rotation) as GameObject;
			newEnemy.name = enemyJSON.name;
			PlayerController pc = newEnemy.GetComponent<PlayerController>();
			pc.isLocalPlayer = false;
			Health h = newEnemy.GetComponent<Health>();
			h.currentHealth = enemyJSON.health;
			h.OnChangeHealth();
			h.destroyOnDeath = true;
			h.isEnemy = true;
			Debug.Log (enemy.activeSelf);
			Debug.Log (newEnemy.name);
		}
	}
}
