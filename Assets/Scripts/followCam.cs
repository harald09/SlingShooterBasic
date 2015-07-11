using UnityEngine;
using System.Collections;

public class followCam : MonoBehaviour {

	public static followCam S;
	public GameObject poi;
    public float posDamping = 1.0f;

	private float camZ;

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}

	void FixedUpdate() {
		if (poi == null) {
			return;
		}

		Vector3 destination = poi.transform.position;

		//Limit the x&y position

		//destination.x = Mathf.Max (0, destination.x);
		destination.y = Mathf.Max (0, destination.y);

		destination.z = camZ; 

		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * posDamping);

		this.GetComponent<Camera> ().orthographicSize = 10+destination.y;
	
	}
	

}
