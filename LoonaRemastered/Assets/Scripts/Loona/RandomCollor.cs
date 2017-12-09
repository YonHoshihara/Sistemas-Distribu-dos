using UnityEngine;
using System.Collections;
//kazuo
public class RandomCollor : MonoBehaviour {
	public Sprite[] Sprites;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
