using UnityEngine;
using System.Collections;


public class SoundController : MonoBehaviour {
	//[SerializeField] private string SceneName;
	[SerializeField]private AudioSource []music;
	private float CanIRandom; 
	public AudioSource BubleSong;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayBubleSound(){

		BubleSong.Play ();
	}
		
	}



