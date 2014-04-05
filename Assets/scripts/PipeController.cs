using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class PipeController : MonoBehaviour {

	public float maxHeight;
	public float minHeight;

	public float rateSpawn;
	private float currentRateSpawn;

	public GameObject pipePrefab;
	public int maxPool;

	private GameController gameController;

	public List<GameObject> pipes;
	public Transform player;

	// Use this for initialization
	void Start () {
		for (int i=0; i < maxPool; i++) {
			GameObject go = Instantiate(pipePrefab) as GameObject;
			go.SetActive(false);
			pipes.Add(go);
		}
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.currentState != GameState.IN_GAME)
			return;

		currentRateSpawn += Time.deltaTime;

		if (currentRateSpawn > rateSpawn) {
			currentRateSpawn = 0;
			Spawn();
		}
	}

	private void Spawn() {
		float height = Random.Range (minHeight, maxHeight);

		GameObject pipe = pipes.FirstOrDefault(go => !go.activeSelf);

		if (pipe != null) {
			pipe.transform.position = new Vector3 (transform.position.x, height, transform.position.z);
			pipe.SetActive(true);
		}

	}
}
