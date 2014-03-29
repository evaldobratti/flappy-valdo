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
	private GameState currentState;
	public Transform scoreTransform;
	private Score score;
	// Use this for initialization
	void Start ()
	{
		startPositionPlayer = player.position;
		currentState = GameState.START;
		score = scoreTransform.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentState) {
		case GameState.START:
			{
				currentState = GameState.IDLE;
				score.Disable();
			}
			break;
		case GameState.IDLE:
			{
				player.position = startPositionPlayer;
				score.Valor = 0;
			}
			break;
		case GameState.IN_GAME:
			{
				score.Enable();
			}
			break;
		case GameState.GAME_OVER:
			{
				FindObjectsOfType<PipeBehavior> ().ToList ().ForEach (i => i.gameObject.SetActive (false));
				currentState = GameState.RANKING;
			}
			break;
		case GameState.RANKING: 
			{
				score.Disable();
				currentState = GameState.START;
			}
			break;
		}
	}

	public void StartGame() {
		currentState = GameState.IN_GAME;
	}

	public GameState CurrentGameState {
		get {
			return currentState;
		}
	}

	public void StopGame ()
	{
		currentState = GameState.GAME_OVER;

	}

	public void addScore() {
		score.Scored ();
	}
}
