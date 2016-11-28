using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GarbageMovementManagerScript : MonoBehaviour {

	public GameObject Garbage;
	public GameObject ArrayObject;
	public GameObject PowergageSliderObject;

	private Rigidbody rb;
	private Slider PowerSlider;
	private bool WasCast = false;

	void Awake () {
		rb = Garbage.GetComponent <Rigidbody> ();
		rb.useGravity = false;
		PowerSlider = PowergageSliderObject.GetComponentInChildren <Slider> ();
	}

	void Update () {
		if (!StaticValueManager.IsStart && Input.GetKeyDown ("return")) {
			StaticValueManager.IsStart = true;
			ArrayObject.SetActive (true);
		}

		if (StaticValueManager.IsStart && Input.GetKeyDown ("space")) {
			if (StaticValueManager.UpperDetermine && StaticValueManager.SideDetermine) {
				StaticValueManager.PowerDetermine = true;
			}
			if (StaticValueManager.UpperDetermine) {
				StaticValueManager.SideDetermine = true;
				PowergageSliderObject.SetActive (true);
			}
			StaticValueManager.UpperDetermine = true;
		}
	}

	void FixedUpdate () {
		if (StaticValueManager.AllDetermine && !WasCast) {
			rb.useGravity = true;
			float anglex = (360 - ArrayObject.transform.eulerAngles.x) * Mathf.PI / 180;
			float angley = (ArrayObject.transform.eulerAngles.y) * Mathf.PI / 180;
			Vector3 push = new Vector3 (Mathf.Sin(angley), Mathf.Sin (anglex), Mathf.Cos (anglex));
			push.Normalize();
			rb.AddForce (push * PowerSlider.value, ForceMode.Impulse);
			WasCast = true;
		}

		if (StaticValueManager.IsGameOver) {
			rb.velocity = Vector3.zero;
		}
	}

	/************************************ OnClickFunction *************************************/
	/****** For Go Button *******/
	public void GoButtonOnClick () {
		if (StaticValueManager.UpperDetermine && StaticValueManager.SideDetermine) {
			StaticValueManager.PowerDetermine = true;
		}
		if (StaticValueManager.UpperDetermine) {
			StaticValueManager.SideDetermine = true;
			PowergageSliderObject.SetActive (true);
		}
		StaticValueManager.UpperDetermine = true;
	}
}
