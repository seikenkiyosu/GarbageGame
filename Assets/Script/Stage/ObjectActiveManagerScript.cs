﻿using UnityEngine;
using System.Collections;

public class ObjectActiveManagerScript : MonoBehaviour {

	public GameObject Garbage;
	public GameObject CeneterCamera;
	public GameObject Cameras;
	public GameObject Field;
	public GameObject Ceil;
	public GameObject FrontWall;
	public GameObject BackWall;
	public GameObject RightWall;
	public GameObject LeftWall;
	public GameObject Wind;
	public GameObject ArrowObject;

	void Awake () {
		Garbage.SetActive (true);
		CeneterCamera.SetActive (true);
		Cameras.SetActive (true);
		Field.SetActive (true);
		Ceil.SetActive (true);
		FrontWall.SetActive (true);
		BackWall.SetActive (true);
		RightWall.SetActive (true);
		LeftWall.SetActive (true);
		Wind.SetActive (false);
		ArrowObject.SetActive (false);
	}

}
