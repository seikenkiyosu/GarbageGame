using UnityEngine;
using System.Collections;

public class ObjectActiveManagerScript : MonoBehaviour {

	public GameObject Garbage;
	public GameObject CeneterCamera;
	public GameObject Cameras;
	public GameObject GarbageBox;
	public GameObject Field;
	public GameObject FrontWall;
	public GameObject BackWall;
	public GameObject RightWall;
	public GameObject Wind;
	public GameObject ArrowObject;

	void Awake () {
		Garbage.SetActive (true);
		CeneterCamera.SetActive (true);
		Cameras.SetActive (true);
		GarbageBox.SetActive (true);
		Field.SetActive (true);
		FrontWall.SetActive (true);
		BackWall.SetActive (true);
		RightWall.SetActive (true);
		Wind.SetActive (true);
		ArrowObject.SetActive (true);
	}

}
