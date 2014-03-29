using UnityEngine;
using System.Collections;

public class ScenarioMoviment : MonoBehaviour {

	private Material currentMaterial;
	public float speed;
	private float offset;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		currentMaterial = renderer.material;
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.CurrentGameState != GameState.IN_GAME)
			return;

		offset += 0.001f;
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0) * speed);
	}
}
