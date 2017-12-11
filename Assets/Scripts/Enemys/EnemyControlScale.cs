using UnityEngine;
using System.Collections;

public class EnemyControlScale : MonoBehaviour {
	private GameObject Player;
	[SerializeField]private float ScalleAdaptation;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");

		if(Player.transform.localScale.x>1f){
			gameObject.transform.localScale = new Vector3 (Player.transform.localScale.x,Player.transform.localScale.y,gameObject.transform.localScale.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
