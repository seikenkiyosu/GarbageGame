using UnityEngine;
using System.Collections;

public class StaticValueManager : MonoBehaviour {

	public static bool IsStart;
	public static bool UpperDetermine;
	public static bool SideDetermine;
	public static bool PowerDetermine;
	public static bool AllDetermine;
	public static bool IsGameClear;
	public static bool IsGameOver;

	void Awake () {
		IsStart = false;
		UpperDetermine = false;
		SideDetermine = false;
		PowerDetermine = false;
		AllDetermine = false;
		IsGameClear = false;
		IsGameOver = false;
	}

}
