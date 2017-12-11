using UnityEngine;
using System.Collections;
//Kazuo
public class TeleportController : MonoBehaviour {
	public float MaxUp, MaxDown, MaxLeft, MaxRight;
	private GameObject Target;
	//public string targettag;
	public float breaker;
	// Use this for initialization
	void Start () {
		//Target = GameObject.FindGameObjectWithTag (targettag);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y>MaxUp){
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x,MaxDown+1,0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity / breaker;

		}else if(gameObject.transform.position.y<MaxDown){
		
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x,MaxUp-1,0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity / breaker;
		}

		if(gameObject.transform.position.x>MaxRight){
			gameObject.transform.position = new Vector3 (MaxLeft+1,gameObject.transform.position.y,0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity / breaker;
		}else if(gameObject.transform.position.x<MaxLeft){
		
			gameObject.transform.position = new Vector3 (MaxRight-1,gameObject.transform.position.y,0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity / breaker;
		}
	}
}
