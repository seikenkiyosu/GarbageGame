using UnityEngine;
using System.Collections;

public class SceneButtonMovement : MonoBehaviour {

    public GameObject SceneButtons;
    public int RowSceneNumbers;
    public int ColumnSceneNumbers;

    public Transform Stage11;
    public Transform Stage12;
    public Transform Stage21;

    public GameObject StartMainCanvasposition;

    private float XCriteria;
    private float YCriteria;
    private float DistanceXBetweenStages;
    private float DistanceYBetweenStages;
    private float StageButtonPositionX;
    private float StageButtonPositionY;
    private float StageFieldSizeX;
    private float StageFieldSizeY;

    void Awake () {
        SceneButtons.SetActive(true);
    }

    void Start () {
        XCriteria = StartMainCanvasposition.transform.position.x;
        YCriteria = StartMainCanvasposition.transform.position.y;
        DistanceXBetweenStages = Stage12.position.x - Stage11.position.x;
        DistanceYBetweenStages = Stage11.position.y - Stage21.position.y;
        StageButtonPositionX = XCriteria;
        StageButtonPositionY = YCriteria;
        StageFieldSizeX = RowSceneNumbers * DistanceXBetweenStages;
        StageFieldSizeY = ColumnSceneNumbers * DistanceYBetweenStages;
        Debug.Log ("XCriteria = " + XCriteria);
        Debug.Log ("YCriteria = " + YCriteria);
        Debug.Log ("Between Distance X = " + DistanceXBetweenStages);
        Debug.Log ("Between Distance Y = " + DistanceYBetweenStages);
        Debug.Log ("StageButtonPositionX = " + StageButtonPositionX);
        Debug.Log ("StageButtonPositionY = " + StageButtonPositionY);
        Debug.Log ("StageFieldSizeX = " + StageFieldSizeX);
        Debug.Log ("StageFieldSizeY = " + StageFieldSizeY);
        // Debug.Log ("RowSceneNumbers * DistanceXBetweenStages - XCriteria = " + (RowSceneNumbers * DistanceXBetweenStages - XCriteria));
        // Debug.Log ("(RowSceneNumbers+1) * DistanceXBetweenStages)" + ((RowSceneNumbers+1) * DistanceXBetweenStages));
    }


    /* OnClickButton */
    float Moveposition = 0.0f;
    public void OnClickUpButton () {
        StageButtonPositionY = ( Mathf.Abs ( StageButtonPositionY - DistanceYBetweenStages - YCriteria + StageFieldSizeY) % StageFieldSizeY) + YCriteria;
        SceneButtons.transform.position = new Vector3(
        SceneButtons.transform.position.x,
        StageButtonPositionY,
        SceneButtons.transform.position.z
        );
    }

    public void OnClickRightButton()
    {
        StageButtonPositionX = -( Mathf.Abs ( StageButtonPositionX - DistanceXBetweenStages - XCriteria ) % StageFieldSizeX ) + XCriteria;
        SceneButtons.transform.position = new Vector3(
            StageButtonPositionX,
            SceneButtons.transform.position.y,
            SceneButtons.transform.position.z
        );
    }

    public void OnClickLeftButton()
    {
        StageButtonPositionX = -( Mathf.Abs (-StageFieldSizeX + StageButtonPositionX + DistanceXBetweenStages - XCriteria) % StageFieldSizeX ) + XCriteria;
        SceneButtons.transform.position = new Vector3(
            StageButtonPositionX,
            SceneButtons.transform.position.y,
            SceneButtons.transform.position.z
        );
    }

    public void OnClickDownButton()
    {
        StageButtonPositionY = ( StageButtonPositionY + DistanceYBetweenStages - YCriteria ) % StageFieldSizeY + YCriteria;
        SceneButtons.transform.position = new Vector3(
        SceneButtons.transform.position.x,
        StageButtonPositionY,
        SceneButtons.transform.position.z
        );
    }
}
