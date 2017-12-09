using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
// Kazuo
public class Move : NetworkBehaviour
{

    private Vector3 direction;
    // private GameObject GameController;
    private TouchController Touch;
    public float force;
	public Vector2 MaxVelocity;
	private Rigidbody2D velocity;
	public float breaker;
    CameraFollowPlayer cameraFollow;


  
    // Use this for initialization
    void Start()
    {
        Touch = GetComponent<TouchController>();
		velocity = gameObject.GetComponent<Rigidbody2D>();
		SetCameraTarget ();
    }
    // Update is called once per frame
    void Update()
    {
		CheckTouch ();
	}
		 
	[Client]
	public void Movement(GameObject obj , Vector3 directionRef,ForceMode2D mode)
    {
		if(!isLocalPlayer){

			return;
		}
		if(Time.timeScale!=0){
			Vector2 direction;
			direction = new Vector2 (directionRef.x-obj.transform.position.x, directionRef.y-transform.position.y);
			direction.Normalize();
			// Debug.Log(direction);
			if(direction.magnitude<= MaxVelocity.magnitude){
				
				//obj.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
				obj.GetComponent<Rigidbody2D>().AddForce(direction*force);
				Touch.SetCanIMove(false);	
		}

		}
    }

	[Client]
	public void CheckTouch(){
		if(isLocalPlayer){
			//Debug.Log ( gameObject.GetComponent<Rigidbody2D>().velocity);
			if (Touch.GetCanIMove())
			{if (Time.timeScale != 0) {
					Movement(gameObject,Touch.Getdirection(),ForceMode2D.Force);
				}
			}
			if( velocity.velocity.magnitude > MaxVelocity.magnitude){

				velocity.velocity = velocity.velocity / breaker;
			}

		}
	}

	[Client]
	public void SetCameraTarget(){
		if(!isLocalPlayer){
			return;
		}
		cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollowPlayer>();
		cameraFollow.target = this.gameObject;
	}

}
