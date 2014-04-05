using UnityEngine;
using System.Collections;
using System.Linq;
public enum GameState
{
	START,
	IDLE,
	IN_GAME,
	GAME_OVER,
	RANKING
	
}

public class GameController : MonoBehaviour
{

	public Transform player;
	private Vector3 startPositionPlayer;
	public GameState currentState;
	public Transform scoreTransform;
	public Score Score { get; set;}

	public ScoreGameOverController gameOverState;

	void Start ()
	{
		startPositionPlayer = player.position;
		currentState = GameState.START;
		Score = scoreTransform.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentState) {
		case GameState.START:
			{
				currentState = GameState.IDLE;
				Score.Disable();
			}
			break;
		case GameState.IDLE:
			{
				if (Input.GetMouseButtonDown(0))
			    	currentState = GameState.IN_GAME;
				player.position = startPositionPlayer;
				Score.Valor = 0;
			}
			break;
		case GameState.IN_GAME:
			{
				Score.Enable();
			}
			break;
		case GameState.GAME_OVER:
			{
				gameOverState.Update(this);
			}
			break;
		case GameState.RANKING: 
			{
				Score.Disable();
				currentState = GameState.START;
			}
			break;
		}
	}

	public void StartGame() {
		currentState = GameState.IN_GAME;
	}


	public void StopGame ()
	{
		currentState = GameState.GAME_OVER;
		gameOverState.stateEntered(this);

	}

	public void addScore() {
		Score.Scored ();
	}
}
