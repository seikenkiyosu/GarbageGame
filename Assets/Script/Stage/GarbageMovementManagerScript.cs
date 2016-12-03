using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GarbageMovementManagerScript : MonoBehaviour {

	public GameObject Garbage;
	public GameObject ArrowObject;
	public GameObject PowergageSliderObject;
	public GameObject ArrowObjectInGarbageBox;

	private Rigidbody rb;
	private Slider PowerSlider;
	private bool WasCast = false;

	void Awake () {
		rb = Garbage.GetComponent <Rigidbody> ();
		rb.useGravity = false;
		PowerSlider = PowergageSliderObject.GetComponentInChildren <Slider> ();
	}

	void Update () {
		if (!StaticValueManager.IsStart && (Input.GetKeyDown ("return") || OnTouchDown()) ) {
			StaticValueManager.IsStart = true;
			ArrowObject.SetActive (true);
			ArrowObjectInGarbageBox.SetActive (true);
		}

		if (StaticValueManager.IsStart && Input.GetKeyDown ("space")) {
			if (StaticValueManager.UpperDetermine && StaticValueManager.SideDetermine) {
				StaticValueManager.PowerDetermine = true;
			}
			if (StaticValueManager.UpperDetermine) {
				StaticValueManager.SideDetermine = true;
				PowergageSliderObject.SetActive (true);
			}
			StaticValueManager.UpperDetermine = true;
		}
	}

	void FixedUpdate () {
		if (StaticValueManager.AllDetermine && !WasCast) {
			ArrowObjectInGarbageBox.SetActive (false);
			rb.useGravity = true;
			float anglex = (360 - ArrowObject.transform.eulerAngles.x) * Mathf.PI / 180;
			float angley = (ArrowObject.transform.eulerAngles.y) * Mathf.PI / 180;
			Vector3 push = new Vector3 (Mathf.Sin(angley), Mathf.Sin (anglex), Mathf.Cos (anglex));
			push.Normalize();
			rb.AddForce (push * PowerSlider.value, ForceMode.Impulse);
			WasCast = true;
		}

		if (StaticValueManager.IsGameOver || StaticValueManager.IsGameClear) {
			rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

	bool OnTouchDown() {
        // タッチされているとき
        if( 0 < Input.touchCount){
            // タッチされている指の数だけ処理
            for(int i = 0; i < Input.touchCount; i++){
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if(t.phase == TouchPhase.Began ){
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit)){
                        //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                        if (hit.collider.gameObject){
                            return true;
                        }
                    }
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }

	/************************************ OnClickFunction *************************************/
	/****** For Go Button *******/
	public void GoButtonOnClick () {
		if (StaticValueManager.UpperDetermine && StaticValueManager.SideDetermine) {
			StaticValueManager.PowerDetermine = true;
		}
		if (StaticValueManager.UpperDetermine) {
			StaticValueManager.SideDetermine = true;
			PowergageSliderObject.SetActive (true);
		}
		StaticValueManager.UpperDetermine = true;
	}
}
