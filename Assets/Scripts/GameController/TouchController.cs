using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
//Kazuo
public class TouchController : NetworkBehaviour {

    private Vector3 Direction;
    private bool CanIMove= false;
    private Vector3 DeltaPosition;
	private SoundController SoundEffects;
	public GameObject FeedBack;
	private GameObject AgoraEssaPorraAcaba;
	private float horizontal, vertical;
	private Vector2 mousePos;
	private GameObject obj;
	//private GameObject Player;

    void Start()
    {
		//SoundEffects = gameObject.GetComponent<SoundController> ();

		//Player = GameObject.FindGameObjectWithTag ("Player");
    }
    void Update()
    {
		TouchCheckDirection ();
    }
		
	public void destroyObj()
	{
		Destroy (AgoraEssaPorraAcaba);
	}
	[Client] 
	public Vector2 Getdirection()
    {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Direction);
        return direction;
    }
public void SetCanIMove(bool move)
    {
        this.CanIMove = move;
    }
public bool GetCanIMove()
    {
        return this.CanIMove;
    }
	IEnumerator DestroyGameObject(GameObject obj){
		yield return new WaitForSecondsRealtime (0.1f);
		Destroy (obj);
	}

	[Client]
	public void TouchCheckDirection(){
		if (Input.GetButtonDown("Fire1"))
		{

			if(!isLocalPlayer){
				return;
			}
			//SoundEffects.PlayBubleSound (); 
			Direction = Input.mousePosition;
			mousePos = Input.mousePosition; 
			obj = FeedBack;
			//horizontal = mousePos.x - (int) Screen.width / 2;
			//vertical = mousePos.y - (int)Screen.height / 2;
			Vector2 Direction2 = Camera.main.ScreenToWorldPoint(mousePos);
			//Direction2 = -1*Camera.main.ScreenToWorldPoint (Direction2);

			//if(Time.timeScale!=0){

				//AgoraEssaPorraAcaba =Instantiate (obj) as GameObject;
				//AgoraEssaPorraAcaba.GetComponent<Transform> ().position = Direction2;
			//}

			//StartCoroutine (DestroyGameObject(obj));


			//Invoke ("destroyObj",0.05f);

			//Debug.Log (FeedBack);



			CanIMove = true;


		}

	
	}

}
