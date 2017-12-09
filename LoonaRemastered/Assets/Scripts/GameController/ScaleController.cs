using UnityEngine;
using System.Collections;
//Kazuo
public class ScaleController : MonoBehaviour {
    public float offset;
	//public GameObject A, B;


	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
		//Debug.Log(CompareScale (A,B));
	}
	public void Eat(GameObject ObjectToAddScale, float ScaleToAdd,float time){

		if(ObjectToAddScale!=null){
			Vector3 Scale = new Vector3 (ScaleToAdd,ScaleToAdd,0);
			iTween.ScaleAdd (ObjectToAddScale,Scale,time);
			//ObjectToAddScale.transform.localScale = new Vector3(ObjectToAddScale.transform.localScale.x+ScaleToAdd,ObjectToAddScale.transform.localScale.y+ScaleToAdd,0);
		}
	}
	public GameObject CompareScale(GameObject ob1,GameObject ob2){
		
		if((ob1==null)|| (ob2 == null)){
			return null;
		}
		if ((ob1 != null) && (ob2 != null)) {
			if (ob1.GetComponent<SpriteRenderer> ().bounds.size.x > ob2.GetComponent<SpriteRenderer> ().bounds.size.x + offset) {
				return ob1;
			} else {
				if (ob1.GetComponent<SpriteRenderer> ().bounds.size.x + offset < ob2.GetComponent<SpriteRenderer> ().bounds.size.x) {
					return ob2;
				} else {
					return null;
				}
			}
		} else {
		
			return null;
		}
}
}