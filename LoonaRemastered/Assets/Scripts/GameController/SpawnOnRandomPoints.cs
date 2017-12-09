using UnityEngine;
using System.Collections;

public class SpawnOnRandomPoints : MonoBehaviour {
	public GameObject objectToSpawn;
	public string spawnPointsTag;
	public int initialQuantityToSpawn;
	public int constantQuantity;
	public string objectParentTag;
	public float timeToCheckSons;
	private GameObject[] spawnPoints;
	private GameObject objectParent;


	// Use this for initialization
	void Start () {                                                      
		spawnPoints = GameObject.FindGameObjectsWithTag (spawnPointsTag);
		objectParent = GameObject.FindGameObjectWithTag (objectParentTag);
		for (int i = 0; i < initialQuantityToSpawn; i++) {
			Spawn ();
		}
		InvokeRepeating ("CheckQuantity", 0, timeToCheckSons);
	}

	void Spawn(){
		GameObject instantiateObject;
		int randomNum = (int)Random.Range (0, spawnPoints.Length);
		Vector2 positionToSpawn = spawnPoints[randomNum].transform.position;
		instantiateObject = Instantiate (objectToSpawn);
		instantiateObject.transform.position = positionToSpawn;
		instantiateObject.transform.parent = objectParent.transform;
	}


	void CheckQuantity(){
		int currentChild = objectParent.transform.childCount;
		int numberToSpawn = constantQuantity - currentChild;
		for (int i = 0; i < numberToSpawn; i++) {
			Spawn ();
		}

	}


}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  