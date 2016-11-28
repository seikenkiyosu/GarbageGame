using UnityEngine;
using System.Collections;

public class GameOverManagerScript : MonoBehaviour {

	public float JudgeTimer = 1.0f;

	private float Timer;

	void Start () {
		Timer = 0.0f;
	}

	void Update () {
		if (Timer > JudgeTimer && !StaticValueManager.IsGameOver) {
			StaticValueManager.IsGameOver = true;
		}
	}

	void OnCollisionStay (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			Timer += Time.deltaTime;
		}
	}

}
