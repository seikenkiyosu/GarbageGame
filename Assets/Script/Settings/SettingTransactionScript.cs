using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingTransactionScript : MonoBehaviour {

	public void SettingButtonOnClick () {
		SceneManager.LoadScene ("Settings", LoadSceneMode.Additive);
	}

}
