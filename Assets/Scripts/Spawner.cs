using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnMinMax;
	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	float nextSpawnTime;

	Vector2 halfScreenSizeWorldUnits;

	// Use this for initialization
	void Start () {
		nextSpawnTime = 0.0f;
		halfScreenSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercentage());
			//print (secondsBetweenSpawns);
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range (-halfScreenSizeWorldUnits.x + spawnSize/2, halfScreenSizeWorldUnits.x - spawnSize/2), halfScreenSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
	}
}
