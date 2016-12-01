using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GointToSceneScript : MonoBehaviour {
	
	private string StageName;

	void StageButtonOnClick (GameObject StageButton) {
		StageName = StageButton.GetComponentInChildren <Text> ().text;
		SceneManager.LoadScene (StageName);
	}
	
}
