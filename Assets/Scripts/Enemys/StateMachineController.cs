using UnityEngine;
using System.Collections;
//kazuo
public class StateMachineController : MonoBehaviour {

	private GameObject Target;
	private Animator StateMachine;
	private GameObject Scale;
	private GameObject [] Food;
	private Vector3 Distance;
	private GameObject Bigger;
	private GameObject obj;
	public float TimeToChangeState;
	private GameObject Player;
	public float MaxDistanceToPlayer;
	// Use this for initialization

	void Awake(){
		Scale = GameObject.FindGameObjectWithTag("Controller");	
		StateMachine = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	void Start () {
		//Debug.Log (Scale.GetComponent<ScaleController>());
	}
	void Update () { 
		if(Target == null){
			StateMachine.SetTrigger ("Walk");
		}
		if(Player!=null){
			Vector3 Aux = Player.transform.position - gameObject.transform.position;
			if(Aux.magnitude<=MaxDistanceToPlayer){
				Bigger = Scale.GetComponent<ScaleController> ().CompareScale (Player,gameObject);
				if(Bigger==Player){
					SetRun (Player, "Run");
					//Debug.Log ("Run");
				}else if(Bigger == gameObject){
					SetRun (Player,"Hunt");
					//Debug.Log ("Hunt");
				}
		}
				
		}
	}
	public GameObject GetTarget(){
		return this.Target;
	}
	void OnTriggerEnter2D(Collider2D other){
		if((other.gameObject.tag == "Enemy")){
			obj = other.gameObject;
			StopCoroutine ("SetWalk");
			if((other.gameObject!=null)&&(gameObject!=null)){
				Bigger = Scale.GetComponent<ScaleController> ().CompareScale (obj,gameObject);
			}
			if (Bigger != null) {
				if (Bigger == obj) {
					if (obj == null) {
						//Debug.Log ("DEU Ruim");
					}
					Target = obj;
					SetRun (obj, "Run");				
				} else if (Bigger == gameObject) {
					Target = obj;
					SetRun (obj, "Hunt");
				} 
			} else {
				StateMachine.SetTrigger ("Walk");
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if ((other.gameObject.tag == "Player") || (other.gameObject.tag == "Enemy")) {
			StartCoroutine ("SetWalk");
		}
	}
	private void SetRun(GameObject ObjectTarget,string TriggerName){
		Target = ObjectTarget;		
		StateMachine.SetTrigger (TriggerName);
	}
	IEnumerator SetWalk (){
		yield return new WaitForSeconds (TimeToChangeState);
		StateMachine.SetTrigger ("Walk");
	}
}
