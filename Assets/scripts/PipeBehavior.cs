using UnityEngine;
using System.Collections;

public class PipeBehavior : MonoBehaviour {

	public float speed;

	private bool hasScored;
	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.CurrentGameState != GameState.IN_GAME)
			return;

		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;

		if (transform.position.x < -10) {
			gameObject.SetActive (false);
		}

		if (transform.position.x < gameController.player.position.x && !hasScored) {
			hasScored = true;
			gameController.addScore();
		}
	}

	void OnEnable() {
		Debug.Log ("zerou");
		hasScored = false;
	}


}
