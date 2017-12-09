using UnityEngine;
using System.Collections;

public class EatOpponent : MonoBehaviour {
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
	[SerializeField] private float MaxTamCamera;
    // Use this for initialization
    void Start () {
        collided = false;  
		scaleController = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScaleController>();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
        score = GameObject.FindGameObjectWithTag("BGcontroller").GetComponent<ScoreManager>();
    }	
    IEnumerator OnCollisionEnter2D(Collision2D other)
    {   
		
			if((other.gameObject.tag == "Enemy")||(other.gameObject.tag == "Player"))
			{ 
			if(gameObject.tag == "Player"){
				Bigger = scaleController.CompareScale(gameObject, other.gameObject);
				if(Bigger == other.gameObject){
					gameObject.GetComponentInChildren<Animator>().SetTrigger("Hurt");
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
                            scaleController.Eat(Bigger, ScalleAddToObject, TimeToAddScale);
                        }            
						if (Bigger == gameObject) {
							collided = false;
							Destroy (obj); 
							if(gameObject.tag == "Player")
							{
								score.SetScore(scoreToAdd);
								if (Camera.GetComponent<Camera> ().orthographicSize <= MaxTamCamera) {
									Camera.GetComponent<Camera> ().orthographicSize = Camera.GetComponent<Camera> ().orthographicSize + ScaleToadjustCamera;
								}
							}
						} else {
							collided = false;
							Destroy (gameObject); 
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
		Destroy (obj); 
	
	}


}
