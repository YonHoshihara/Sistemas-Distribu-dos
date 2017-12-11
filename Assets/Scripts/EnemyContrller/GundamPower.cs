using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
//Isabella
public class GundamPower : NetworkBehaviour {
    public float percentToAdd;
    private ScaleController scaleController;
    private float ScalleAddToObject;
    public float TimeToAddScale;
    // Use this for initialization
    void Start () {
        scaleController = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScaleController>();
    }
	
    void OnCollisionEnter2D(Collision2D other)
    {	
        //Debug.Log(other.gameObject.tag);
        if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Player"))
        {
            
			if(other.gameObject.tag == "Player"){
				//Handheld.Vibrate ();
			}


			ScalleAddToObject = other.gameObject.GetComponent<SpriteRenderer>().bounds.size.x * percentToAdd / 100;
            //scaleController.Eat(other.gameObject, -ScalleAddToObject);
        }

    }
}
