using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasManagerScript : MonoBehaviour {

	public GameObject MainCanvas;
	public GameObject PleaseEnterObject;
	public GameObject GoButtonObject;
	public GameObject GameClearObject;
	public GameObject NextStageButton;
	public string NextStageName;
	public GameObject GameOverObject;
	public GameObject TryAgainButton;
	public GameObject PowerSliderObject;
	public GameObject ManagerCameraButton;
	public GameObject MainCamerasButton;
    public bool DefaultCameraOn;

    public GameObject CenterCamera;
	public GameObject UpCamera;
	public GameObject RightCamera;
	public GameObject LeftCamera;
	public GameObject ButtomCamera;

	public float PleaseEnterAppearInterval = 0.8f;

	private float NextTimeForPleaseEnter;
	private Slider PowerSlider;
	private GameObject CurrentCamera;
    private bool CameraOn;

	void Awake () {
		MainCanvas.SetActive (true);
		PleaseEnterObject.SetActive (false);
		GoButtonObject.SetActive (false);
		GameClearObject.SetActive (false);
		NextStageButton.SetActive (false);
		GameOverObject.SetActive (false);
		TryAgainButton.SetActive (false);
		PowerSliderObject.SetActive (false);
		ManagerCameraButton.SetActive(false);
		MainCamerasButton.SetActive (false);

		CenterCamera.SetActive (true);
		UpCamera.SetActive (false);
		RightCamera.SetActive (false);
		LeftCamera.SetActive (false);
		ButtomCamera.SetActive (false);
		CurrentCamera = CenterCamera;

        GameClearObject.transform.localScale = Vector3.zero;
        NextStageButton.transform.localScale = Vector3.zero;
        GameOverObject.transform.localScale = Vector3.zero;
        TryAgainButton.transform.localScale = Vector3.zero;

        CameraOn = DefaultCameraOn;
		NextTimeForPleaseEnter = Time.time;
	}

	void Update () {
		if (!StaticValueManager.IsStart) {
			PleaseEnter ();
		} else {
			PleaseEnterObject.SetActive (false);
        }

		if (StaticValueManager.IsStart) {
            GoButtonObject.SetActive(true);
            ManagerCameraButton.SetActive(true);
            if (CameraOn) {
                ManagerCameraButton.GetComponentInChildren<Text>().text = "CameraButton Off";
                MainCamerasButton.SetActive(true);
            }
            else {
                ManagerCameraButton.GetComponentInChildren<Text>().text = "CameraButton On";
                MainCamerasButton.SetActive(false);
            }
            ChangeCamera ();
		}

		if (StaticValueManager.IsGameClear) {
			GameClear ();
		}

		if (StaticValueManager.IsGameOver) {
			GameOver ();
        }
	}

	private void PleaseEnter () {
        if (Time.time > NextTimeForPleaseEnter) {
            PleaseEnterObject.SetActive(!PleaseEnterObject.activeInHierarchy);
            NextTimeForPleaseEnter += PleaseEnterAppearInterval;
        }
        //PleaseEnterObject.SetActive (true);
    }

	private void GameClear () {
		GameClearObject.SetActive(true);
		GameClearObject.GetComponent <Animator> ().SetTrigger ("GameClear");
		NextStageButton.SetActive(true);
		NextStageButton.GetComponent <Animator> ().SetTrigger ("NextStage");
	}

	public void GoingNextStage () {		//included by button.onClick in NextStageButton
		SceneManager.LoadScene (NextStageName);
	}

	private void GameOver () {
		GameOverObject.SetActive(true);
		GameOverObject.GetComponent <Animator> ().SetTrigger ("GameOver");
		TryAgainButton.SetActive(true);
		TryAgainButton.GetComponent <Animator> ().SetTrigger ("TryAgain");
	}

	public void TryingAgain () {		//included by button.onClick in TryAgainButton
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void ChangeCamera () {
		if (Input.GetKeyDown("return")) {
			CurrentCamera.SetActive (false);
			CurrentCamera = CenterCamera;
			CurrentCamera.SetActive (true);
		}
		if (Input.GetKey("up")) {
			CurrentCamera.SetActive (false);
			CurrentCamera = UpCamera;
			CurrentCamera.SetActive (true);
		}
		if (Input.GetKey("right")) {
			CurrentCamera.SetActive (false);
			CurrentCamera = RightCamera;
			CurrentCamera.SetActive (true);
		}
		if (Input.GetKey("left")) {
			CurrentCamera.SetActive (false);
			CurrentCamera = LeftCamera;
			CurrentCamera.SetActive (true);
		}
		if (Input.GetKey("down")) {
			CurrentCamera.SetActive (false);
			CurrentCamera = ButtomCamera;
			CurrentCamera.SetActive (true);
		}
	}

	/************************************ OnClickFunction *************************************/

	/****** For Camera Button *******/
	public void StartButtonOnClick () {
		SceneManager.LoadScene ("Start");
	}

	public void ManagerCameraButtonOnClick () {
		if (CameraOn) {
            CameraOn = false;
		} else {
            CameraOn = true;
		}
	}

	public void CenterButtonOnClick () {
		CurrentCamera.SetActive (false);
		CurrentCamera = CenterCamera;
		CurrentCamera.SetActive (true);
	}

	public void UpButtonOnClick () {
		CurrentCamera.SetActive (false);
		CurrentCamera = UpCamera;
		CurrentCamera.SetActive (true);
	}


	public void RightButtonOnClick () {
		CurrentCamera.SetActive (false);
		CurrentCamera = RightCamera;
		CurrentCamera.SetActive (true);
	}

	public void LeftButtonOnClick () {
		CurrentCamera.SetActive (false);
		CurrentCamera = LeftCamera;
		CurrentCamera.SetActive (true);
	}

	public void ButtomButtonOnClick () {
		CurrentCamera.SetActive (false);
		CurrentCamera = ButtomCamera;
		CurrentCamera.SetActive (true);
	}
	/********************************/
}
