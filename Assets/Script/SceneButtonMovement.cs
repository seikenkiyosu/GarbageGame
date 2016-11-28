using UnityEngine;
using System.Collections;

public class SceneButtonMovement : MonoBehaviour {

    public GameObject SceneButtons;

    void Awake () {
        SceneButtons.SetActive(true);
    }



    /* OnClickButton */
    public void OnClickUpButton () {
        Debug.Log("Up button!!");
        SceneButtons.transform.position = new Vector3 (
            SceneButtons.transform.position.x,
            SceneButtons.transform.position.y + 1000,
            SceneButtons.transform.position.z
            );
    }

    public void OnClickRightButton()
    {
        Debug.Log("Right button!!");
        SceneButtons.transform.position = new Vector3(
            SceneButtons.transform.position.x - 1000,
            SceneButtons.transform.position.y,
            SceneButtons.transform.position.z
            );
    }

    public void OnClickLeftButton()
    {
        SceneButtons.transform.position = new Vector3(
            SceneButtons.transform.position.x + 1000,
            SceneButtons.transform.position.y,
            SceneButtons.transform.position.z
            );
    }

    public void OnClickDownButton()
    {
        SceneButtons.transform.position = new Vector3(
            SceneButtons.transform.position.x,
            SceneButtons.transform.position.y - 1000,
            SceneButtons.transform.position.z
            );
    }
}
