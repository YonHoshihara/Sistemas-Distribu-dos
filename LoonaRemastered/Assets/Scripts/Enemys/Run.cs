using UnityEngine;
using System.Collections;
//kazuo
public class Run : StateMachineBehaviour {
	private StateMachineController State;
	private GameObject Target, ThisGameObject; 
	private Vector2 Direction;
	public float Speed;
	private MonoBehaviour script;
	public float TimeToChangeState;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		State = animator.gameObject.GetComponentInChildren<StateMachineController> ();
		Target = State.GetTarget ();
		ThisGameObject = animator.gameObject;
		script= animator.GetComponent<StateMachineController>();

	}
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(Target!=null){
			Direction =  -1*( Target.transform.position-ThisGameObject.transform.position);
			//Debug.Log (Direction.normalized);
			ThisGameObject.GetComponent<Rigidbody2D> ().velocity = Direction.normalized*Speed;
			script.StartCoroutine (SetWalk());
		}
	}
	IEnumerator SetWalk(){
		yield return new WaitForSecondsRealtime (TimeToChangeState);
		ThisGameObject.GetComponent<Animator> ().SetTrigger ("Walk");
	}





}
