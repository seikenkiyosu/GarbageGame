using UnityEngine;
using System.Collections;

public class GameClearManagerScript : MonoBehaviour {

	public float JudgeTimer = 1.0f;

	private float Timer;

	void Start () {
		Timer = 0.0f;
	}

	void Update () {
		if (Timer > JudgeTimer && !StaticValueManager.IsGameClear) {
			StaticValueManager.IsGameClear = true;
		}
	}

	void OnCollisionStay (Collision collision) {
		if (collision.gameObject.tag == "BottomOfGarbageBox") {
			Timer += Time.deltaTime;
		}
	}

}
