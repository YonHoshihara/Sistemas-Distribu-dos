using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
// Kazuo
public class EatCandy : NetworkBehaviour {
	public string FoodTag;
    //private ScoreManager score;
	public float TimeToAddScale;
	private ScaleController Scale;
	private float ScalleAddToObject;
	public float percentToAdd;
    //public int scoreToAdd;
    private GameObject Camera;
	//public float MaxTamCamera;
	[SerializeField] private float ScaleToadjustCamera;


	void Awake(){
		Scale = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScaleController>();
//        score = GameObject.FindGameObjectWithTag("BGcontroller").GetComponent<ScoreManager>();
    }

	void Start () {
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	void Update () {
		
		}
	void OnTriggerEnter2D(Collider2D other){

		try{
			if(other.gameObject.tag == FoodTag){



				if ((this.gameObject.tag == "Player") && (this.gameObject.tag != "Enemy")) {
                  
                    /* if (Camera.GetComponent<Camera>().orthographicSize <= MaxTamCamera)
                     {
                         Camera.GetComponent<Camera>().orthographicSize = Camera.GetComponent<Camera>().orthographicSize + ScaleToadjustCamera;
                     }
                    */
					
				}
				if(other.gameObject!=null){
                    if (gameObject.GetComponent<SpriteRenderer>().bounds.size.x <= 20)
                    {
                        
						ScalleAddToObject = other.gameObject.GetComponent<SpriteRenderer>().bounds.size.x * percentToAdd / 100;
						CmdScaleAdd(gameObject, ScalleAddToObject);
						//adjustCamera();
                    }
					CmdDestroyObject (other.gameObject);
					//score.SetScore(scoreToAdd);
				}

			}

		}catch(MissingReferenceException e){
			print (e);
		}

	}
	[Command]	
	public void CmdDestroyObject (GameObject obj){
		//Debug.Log ("Doce Destruído por "+ this.gameObject.GetComponent<NetworkIdentity>().netId.ToString());
		Destroy (obj);
	}
	[Command]
	public void CmdScaleAdd(GameObject obj, float scaleUpdate){
	
		Scale.RpcEat (obj,scaleUpdate);
	}

	public void adjustCamera(){
		if(!isLocalPlayer){
			return;
			Camera.GetComponent<Camera> ().orthographicSize = Camera.GetComponent<Camera> ().orthographicSize + ScaleToadjustCamera;
		}
	}

}
