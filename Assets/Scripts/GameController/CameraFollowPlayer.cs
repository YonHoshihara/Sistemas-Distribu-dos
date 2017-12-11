using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
//Lucas Almeida
public class CameraFollowPlayer : NetworkBehaviour {
	public float Velocity;
	public GameObject target;
	public Vector3 offset;
	public float MaxX,MinX, MaxY,MinY;
	private GameObject MainCamera;
	private float RelativeVelocity;
	public Vector3 targetPos,CameraInitialPosition;
	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
		MainCamera = gameObject;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		CameraMoviment ();
	}

	[Client]
	Vector3 CheckLimits(Vector3 LimitVectorChecker)
	{
		if (LimitVectorChecker.x > MaxX)
		{
			LimitVectorChecker= new Vector3(MaxX,LimitVectorChecker.y,LimitVectorChecker.z);
		}
		if (LimitVectorChecker.x < MinX)
		{
			LimitVectorChecker= new Vector3(MinX,LimitVectorChecker.y,LimitVectorChecker.z);
		}
		if (LimitVectorChecker.y > MaxY)
		{
			LimitVectorChecker= new Vector3(LimitVectorChecker.x,MaxY,LimitVectorChecker.z);
		}
		if (LimitVectorChecker.y < MinY)
		{
			LimitVectorChecker= new Vector3(LimitVectorChecker.x,MinY,LimitVectorChecker.z);
		}
		return LimitVectorChecker;
	}
		
	[Client]
	public void CameraMoviment(){

		Vector3 LimitVectorChecker;
		Vector3 posNoZ = MainCamera.transform.position;
		if(target!=null){
			posNoZ.z = target.transform.position.z;

		}
		if(target!=null){
			Vector3 targetDirection = (target.transform.position - posNoZ);
			RelativeVelocity = targetDirection.magnitude * Velocity;

			targetPos = MainCamera.transform.position + (targetDirection.normalized * RelativeVelocity * Time.deltaTime);
			LimitVectorChecker = Vector3.Lerp(MainCamera.transform.position, targetPos + offset, 0.25f);
			//CheckLimits(LimitVectorChecker);
			MainCamera.transform.position = CheckLimits(LimitVectorChecker);
		}

	}
}