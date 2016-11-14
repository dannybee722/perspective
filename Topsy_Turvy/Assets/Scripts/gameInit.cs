using Rewired;
using UnityEngine;
using System.Collections;

public class gameInit : MonoBehaviour {

	public static gameInit instance = null;
	public Player rewiredPlayer;

	void Awake() {
		if (instance == null) instance = this;
		else if (instance != this) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);


		Application.targetFrameRate = 60;
		rewiredPlayer = ReInput.players.GetPlayer(0);
	}
}
