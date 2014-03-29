using UnityEngine;
using System.Collections;

public enum GameState
{
	START,
	IDLE,
	IN_GAME,
	GAME_OVER
	
}

public class GameController : MonoBehaviour
{

	public Transform player;
	private Vector3 startPositionPlayer;
	private GameState currentState;
	// Use this for initialization
	void Start ()
	{
		startPositionPlayer = player.position;
		currentState = GameState.START;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentState) {
		case GameState.START:
			{
				player.position = startPositionPlayer;
				currentState = GameState.IDLE;
			}
			break;
		case GameState.IDLE:
			{
				player.position = startPositionPlayer;
			}
			break;
		case GameState.IN_GAME:
			{
			}
			break;
		case GameState.GAME_OVER:
			{
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
}
