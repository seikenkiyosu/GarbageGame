﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastDecisionManagerScript : MonoBehaviour {

	public GameObject Garbage;
	public GameObject ArrayObject;
	public float ArrowRotateSpeed = 50.0f;
	public float BetweenGarbageAndArrow = 1.0f;
	public GameObject PowerSliderObject;
	public float MaxPowerValue;
	public float PowergageSpeedSmoothing = 1.0f;

	private Vector3 ArrowAxisPosition;	//initialized in Start Function
	private bool vxisPositive = true;
	private bool vyisPositive = true;
	private Slider PowerSlider;
	private float PowerGageSpeed;
	private bool PowervIsPositive = true;
	private GameObject PowergageMaxValue;
	private GameObject PowergageMediumValue;

	void Awake () {
		ArrayObject.SetActive (false);
		PowerSliderObject.SetActive (false);
	}

	void Start () {
		PowerSlider = PowerSliderObject.GetComponentInChildren <Slider> ();
		ArrowAxisPosition = Garbage.transform.position;
		ArrayObject.transform.position = ArrowAxisPosition + new Vector3 (0.0f, -0.5f, BetweenGarbageAndArrow+1);
		PowerSlider.maxValue = MaxPowerValue;
		PowerGageSpeed = PowerSlider.maxValue;
		PowergageMaxValue = PowerSliderObject.transform.Find("MaxValue").gameObject;
		PowergageMediumValue = PowerSliderObject.transform.Find("MediumValue").gameObject;
		PowergageMaxValue.GetComponent <Text> ().text = (PowerSlider.maxValue).ToString ();
		PowergageMediumValue.GetComponent <Text> ().text = (PowerSlider.maxValue / 2.0f).ToString ();
	}

	void Update () {
		if (StaticValueManager.IsStart && !ArrayObject.activeInHierarchy && !PowerSliderObject.activeInHierarchy) {
			ArrayObject.SetActive (true);
			PowerSliderObject.SetActive (true);
		}

		if (StaticValueManager.IsStart) {
			if (!StaticValueManager.UpperDetermine) {
				Updown();
			}
			else if (!StaticValueManager.SideDetermine) {
				RightLeft ();
			}
			else if (!StaticValueManager.PowerDetermine) {
				MovePowergage ();
			}
			else {
				StaticValueManager.AllDetermine = true;
			}
		}
	}

	private void Updown () {
		if (vxisPositive) {
			ArrayObject.transform.RotateAround (ArrowAxisPosition, new Vector3(-BetweenGarbageAndArrow,0,0), ArrowRotateSpeed * Time.deltaTime);
			if (ArrayObject.transform.position.z <= Garbage.transform.position.z + BetweenGarbageAndArrow && ArrayObject.transform.position.y > Garbage.transform.position.y) {
				vxisPositive = false;
			}
		} else if (!vxisPositive) {
			ArrayObject.transform.RotateAround (ArrowAxisPosition, new Vector3(BetweenGarbageAndArrow,0,0), ArrowRotateSpeed * Time.deltaTime);
			if (ArrayObject.transform.position.y <= Garbage.transform.position.y - BetweenGarbageAndArrow * 2 && ArrayObject.transform.position.y < Garbage.transform.position.y) {
				vxisPositive = true;
			}
		}
	}

	private void RightLeft () {
		if (vyisPositive) {
			ArrayObject.transform.RotateAround (ArrowAxisPosition, new Vector3 (0, -BetweenGarbageAndArrow, 0), ArrowRotateSpeed * Time.deltaTime);
			if (ArrayObject.transform.position.z <= Garbage.transform.position.z + BetweenGarbageAndArrow && ArrayObject.transform.position.x < Garbage.transform.position.x) {
				vyisPositive = !vyisPositive;
			}
		} else {
			ArrayObject.transform.RotateAround (ArrowAxisPosition, new Vector3 (0, BetweenGarbageAndArrow, 0), ArrowRotateSpeed * Time.deltaTime);
			if (ArrayObject.transform.position.z <= Garbage.transform.position.z + BetweenGarbageAndArrow && ArrayObject.transform.position.x > Garbage.transform.position.x) {
				vyisPositive = !vyisPositive;
			}
		}
	}

	private void MovePowergage () {
			if (PowervIsPositive) {
				PowerSlider.value = PowerSlider.value + Time.deltaTime * PowerGageSpeed * PowergageSpeedSmoothing;
			}
			else {
				PowerSlider.value = PowerSlider.value - Time.deltaTime * PowerGageSpeed * PowergageSpeedSmoothing;
			}
			if (PowerSlider.value <= 0) {
				PowervIsPositive = true;
			}
			if (PowerSlider.value >= MaxPowerValue) {
				PowervIsPositive = false;
			}
		}
}
