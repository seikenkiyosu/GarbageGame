using UnityEngine;
using System.Collections;

public class CameraPositionScript : MonoBehaviour {
	public GameObject Target;
	public Vector3 DistanceFromGarbage;

	void Update () {
		transform.position = Target.transform.position + DistanceFromGarbage;
	}
}
