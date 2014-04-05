using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public Transform mesh;
	public float flyForce;
	private Animator animator;

	private float currentTimeToAnim;
	private bool inAnim = false;
	private float originalGravity;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		animator = mesh.GetComponent<Animator> ();
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
		originalGravity = rigidbody2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetMouseButtonDown(0) && gameController.currentState == GameState.IN_GAME ) 
		{
			inAnim = true;
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(new Vector2(0, 1) * flyForce);
		} 


		if (gameController.currentState != GameState.IN_GAME &&
		    gameController.currentState != GameState.GAME_OVER) {
			rigidbody2D.gravityScale = 0;
			return;
		} else {
			rigidbody2D.gravityScale = originalGravity;
		}
		if (inAnim) 
		{
			currentTimeToAnim += Time.deltaTime;
			if (currentTimeToAnim > 0.4f) 
			{
				currentTimeToAnim = 0;
				inAnim = false;
			}
		}

		animator.SetBool("flyCall", inAnim);

		if (rigidbody2D.velocity.y < 0) {
			mesh.eulerAngles -= new Vector3(0,0,2f);
			if (mesh.eulerAngles.z < 330 && mesh.eulerAngles.z > 30)
				mesh.eulerAngles = new Vector3(0,0,330);
		}
		else if (rigidbody2D.velocity.y > 0) {
			mesh.eulerAngles += new Vector3(0,0,2f);
			if (mesh.eulerAngles.z > 30)
				mesh.eulerAngles = new Vector3(0,0,30);
		}


	}

	public void OnCollisionEnter2D(Collision2D collision) {
		if (gameController.currentState == GameState.IN_GAME)
			gameController.StopGame ();

	}
}
