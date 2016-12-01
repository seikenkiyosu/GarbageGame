using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GointToSceneScript : MonoBehaviour {
	
	private string stageName;

	public void StageButtonOnClick (GameObject StageButton) {
		stageName = StageButton.GetComponentInChildren <Text> ().text;
		SceneManager.LoadScene (stageName);
	}

}
