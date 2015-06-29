using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {

	//Inspector fields

	public int numClouds = 40;

	public Vector3 cloudPosMin;
	public Vector3 cloudPosMax;

	public GameObject[] cloudPrefabs;

	//private fields

	GameObject[] cloudInstances;

	void Awake() {

		//Make an array large enough to hold all clouds
		cloudInstances = new GameObject[numClouds];

		//Find the Cloud Parent Object 

		GameObject cloudParent = GameObject.Find("Clouds");

		//Iterate and generate each cloud in a loop
		for(int i=0; i<numClouds; i++);
			
			//Randomly choose one of the prefabs
			int chosenPrefab = Random.Range(0,cloudPrefabs.Length);

			//Instantiate it
			GameObject CloudCrafter = Instantiate(cloudPrefabs[chosenPrefab]);
			
			//Set a random position and scale
			Vector3 cPos = Vector3.zero;
			cPos.x = Random.RangeAttribute(cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.RangeAttribute(cloudPosMin.y, cloudPosMax.y);

			//Make the cloud a child of our Parent Object
			CloudCrafter.Transform.parent = cloudParent.Transform;
			
			//Add the
			cloudInstances[i] = cloud;
	}
}



