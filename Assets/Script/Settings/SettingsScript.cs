using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsScript : MonoBehaviour {

	public void BackButtonOnClick () {
		SceneManager.UnloadScene ("_Settings");
	}

}
