using UnityEngine;
using System.Collections;
//kazuo
public class Walk : StateMachineBehaviour {
	
	//private StateMachineController State;
	private GameObject Target, ThisGameObject; 
	private Vector2 Direction;
	public float Speed;
	[SerializeField] private float TimeDelay;
	private MonoBehaviour script;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//State = animator.gameObject.GetComponentInChildren<StateMachineController> ();
		script= animator.GetComponent<StateMachineController>();
		ThisGameObject = animator.gameObject;
		script.StartCoroutine (Move());
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	}
	IEnumerator Move(){
		//yield return new WaitForSeconds (TimeDelay);
		GameObject[] Food = GameObject.FindGameObjectsWithTag ("Food");
		int i = Random.Range (0,Food.Length-1);
		Target = Food [i];
		Direction = Target.transform.position - ThisGameObject.transform.position;
		ThisGameObject.GetComponent<Rigidbody2D> ().velocity = Direction.normalized * Speed;
		yield return new WaitForSeconds (TimeDelay);
		script.StartCoroutine (Move());
	}
}