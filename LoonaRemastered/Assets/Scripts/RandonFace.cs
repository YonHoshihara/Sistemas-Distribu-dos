using UnityEngine;
using System.Collections;

public class RandonFace : MonoBehaviour {
	public Sprite[] Faces;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = Faces[Random.Range(0,Faces.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
