using UnityEngine;

using System.Collections;

public class HowfarManagerScript : MonoBehaviour {

	public GameObject GarbageBox;
	public int decimalNumber = 2;

	private GameObject Garbage;
	private float distance;
	private string distanceString;

	void Start () {
		Garbage = GameObject.FindWithTag ("Garbage");
		distance = Vector3.Distance (Garbage.transform.position, GarbageBox.transform.position);
		distance = Mathf.Round ( distance *  (float) Mathf.Pow (10, decimalNumber) ) / (float) Mathf.Pow (10, decimalNumber);
		distanceString = distance.ToString ();

		this.GetComponent <TextMesh> ().text = distanceString + "m";
	}

}
