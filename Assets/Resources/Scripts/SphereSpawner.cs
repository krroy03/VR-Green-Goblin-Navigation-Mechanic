using UnityEngine;
using System.Collections;

public class SphereSpawner : MonoBehaviour {

	public GameObject spawnedPrefab;

	public Transform target;

	public float maxSpawnInterval = 1.0f; 
	public float minSpawnInterval = 1.0f;
	public float spawnInterval = 1.0f;

	public float prefabSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		spawnInterval = Random.Range (minSpawnInterval, maxSpawnInterval);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time % spawnInterval < 0.01f) {
			SpawnPrefab ();
		}
	}

	void SpawnPrefab() {
		Vector3 spawnPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 30.0f, this.transform.position.z);
		Vector3 targetDir = target.position - spawnPosition; 
		GameObject spawned = GameObject.Instantiate (spawnedPrefab, spawnPosition  , spawnedPrefab.transform.rotation) as GameObject;
		spawned.GetComponent<Rigidbody>().velocity = targetDir.normalized * prefabSpeed;
	}
}
