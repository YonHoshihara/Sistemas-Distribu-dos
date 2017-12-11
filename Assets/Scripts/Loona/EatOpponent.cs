using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EatOpponent : NetworkBehaviour {
    // Isabella
    public GameObject Object;
    private bool collided;
    private ScoreManager score;
    public int scoreToAdd;
	private ScaleController scaleController;
    private GameObject Bigger;
    public float percentToAdd;
    public float TimeToAddScale;
    private float ScalleAddToObject;
    public float TimeToEat;
	private GameObject obj;
	public  float ScaleToadjustCamera;
	private GameObject Camera;
	private Vector3 StartScale;
	//[SyncVar]public bool IsDead= false;

	[SerializeField] private float MaxTamCamera;
    // Use this for initialization
	[Client]
	void Start () {
        collided = false;  
		scaleController = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScaleController>();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		StartScale = gameObject.transform.localScale;
       // score = GameObject.FindGameObjectWithTag("BGcontroller").GetComponent<ScoreManager>();
    }	
    
	IEnumerator OnCollisionEnter2D(Collision2D other)
    {   
		
			if((other.gameObject.tag == "Enemy")||(other.gameObject.tag == "Player"))
			{ 
			if(gameObject.tag == "Player"){
				Bigger = scaleController.CompareScale(gameObject, other.gameObject);
				if(Bigger == other.gameObject){
					//gameObject.GetComponentInChildren<Animator>().SetTrigger("Hurt");
					//Handheld.Vibrate ();
				}

			}
				yield return new WaitForSeconds(TimeToEat);
				collided = true;
			try{
				obj = other.gameObject;
				Bigger = scaleController.CompareScale(gameObject, obj);
				ScalleAddToObject = other.gameObject.GetComponent<SpriteRenderer>().bounds.size.x * percentToAdd / 100;
				if (collided) { 
					if (Bigger!=null)
					{
                        if (Bigger.GetComponent<SpriteRenderer>().bounds.size.x <= 20)
                        {
							CmdScaleAdd(Bigger, ScalleAddToObject);
                        }            
						if (Bigger == gameObject) {
							collided = false;
							CmdDestroyObj (obj); 
							if(gameObject.tag == "Player")
							{
								//score.SetScore(scoreToAdd);
								if (Camera.GetComponent<Camera> ().orthographicSize <= MaxTamCamera) {
									//Camera.GetComponent<Camera> ().orthographicSize = Camera.GetComponent<Camera> ().orthographicSize + ScaleToadjustCamera;
									//adjustCamera();
								}
							}
						} else {
							collided = false;

							CmdDestroyObj(gameObject); 
						}
					}     
				} 

			}
			catch(MissingReferenceException e){
				print (e);
			}

			}
	}
    void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Player"))
        {
            collided = false;
            StopCoroutine("OnCollisionEnter2D");
        }     
    }
	IEnumerator DestroyOnTime(GameObject obj,float TimeToDestroy){
		yield return new WaitForSeconds (TimeToDestroy);
		obj.GetComponent<EatOpponent> ().RpcRespawn ();
		//CmdDestroyObj (obj); 
	
	}
	[Command]
	public void CmdDestroyObj(GameObject obj){
		obj.GetComponent<EatOpponent> ().RpcRespawn ();
		//Destroy (obj);
	}
	[Command]
	public void CmdScaleAdd(GameObject obj, float scaleUpdate){

		//obj.GetComponent<EatOpponent> ().die = true;
		scaleController.RpcEat (obj,scaleUpdate);
	}

	[Client]
	public void adjustCamera(){
		if(!isLocalPlayer){
			return;
			Camera.GetComponent<Camera> ().orthographicSize = Camera.GetComponent<Camera> ().orthographicSize + ScaleToadjustCamera;
		}
	}

	[ClientRpc]
	public void RpcRespawn(){
		Transform spawn = NetworkManager.singleton.GetStartPosition ();
		gameObject.transform.localScale = StartScale;
		gameObject.transform.position = spawn.position;
	}	

}
