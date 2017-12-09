using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	private GameObject Player;
	public GameObject Score;
	[SerializeField] private Animator Animation; 
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Player == null ){
			Score.SetActive (false);
			Animation.SetTrigger ("GameOver");
			Time.timeScale = 0;

		}
	}
}
