using UnityEngine;
using System.Collections;
using System.Linq;
public class ScoreGameOverController : MonoBehaviour {

	public Score bestScore;
	public Score lastScore;


	public SpriteRenderer medalGold;
	public SpriteRenderer medalSilver;
	public SpriteRenderer medalBronze;
	public SpriteRenderer medalPlatinum;

	private bool shouldReinitialize;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Update(GameController controller) {
		if (Input.GetMouseButtonDown (0)) {
			if (shouldReinitialize) {
				gameObject.SetActive(false);
				controller.currentState = GameState.START;
				return;
			} else
				shouldReinitialize = true;
		}

		lastScore.Valor = controller.Score.Valor;
		bestScore.Valor = PlayerPrefs.GetInt ("bestScore");
	}

	private void disableMedals() {
		medalGold.enabled = false;
		medalSilver.enabled = false;
		medalBronze.enabled = false;
		medalPlatinum.enabled = false;
	}

	public void stateEntered(GameController controller) {
		shouldReinitialize = false;
		Debug.Log("finalizou" + PlayerPrefs.GetInt ("bestScore"));
		if (controller.Score.Valor > PlayerPrefs.GetInt ("bestScore")) {
			PlayerPrefs.SetInt ("bestScore", controller.Score.Valor);
		}



		disableMedals ();

		if (lastScore.Valor < 1) {
			medalBronze.enabled = true;
		} else if (lastScore.Valor < 2) {
			medalSilver.enabled = true;
		} else if (lastScore.Valor < 3) {
			medalGold.enabled = true;
		} else {
			medalPlatinum.enabled = true;
		}

		FindObjectsOfType<PipeBehavior> ().ToList ().ForEach (i => i.gameObject.SetActive (false));
		


		gameObject.SetActive (true);
	}
}

