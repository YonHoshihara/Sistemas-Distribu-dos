using UnityEngine;
using System.Collections;

public class CameraScaleToPlayer : MonoBehaviour {
	private Vector3 PlayerSize, CameraSize;
	private GameObject PlayerController,Player;
	private BoxCollider2D CameraSizeReference;
	private bool CanAjust=true;
	// Use this for initialization
	void Start () {
		//PlayerController = GameObject.Find("PlayerController");
		//CameraSizeReference = GameObject.Find("CameraReferenceSize").GetComponent<BoxCollider2D>();
		//Player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void FixedUpdate () {



		if ((Time.timeScale != 0)&&(GetComponent<Camera>().orthographicSize<=12))
		{
			if (CanAjust)
			{
				GetComponent<Camera>().orthographicSize = (CameraSizeReference.bounds.size.y)/2 ; //orthographicSize= Vertical Height/2
			}
		}
	}
	public void SetCanAjust(bool Ajust)
	{
		CanAjust = Ajust;
	}

}
