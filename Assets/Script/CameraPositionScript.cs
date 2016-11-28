using UnityEngine;
using System.Collections;

public class CameraPositionScript : MonoBehaviour {
	public GameObject Garbage;
	public Vector3 DistanceFromGarbage;

	void Update () {
		transform.position = Garbage.transform.position + DistanceFromGarbage;
	}
}
