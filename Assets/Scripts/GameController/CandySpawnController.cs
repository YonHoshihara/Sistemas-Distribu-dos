using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

//Isabella e Jhone do Passado
public class CandySpawnController : NetworkBehaviour {
	public float Bgmin_x, BGmax_x, BGmin_y, BGmax_y;
	public GameObject candy;
	[SerializeField]private int maxAmount;
	private GameObject Object;
	public  float TimeToInstantiate;
	private Vector3 vector = new Vector3();

	// Use this for initialization
	[Server] 
	void Start () {
		//Debug.Log ("Start");
		if (!isServer) {

			return;
		} else {
			
			RpcInstantiateCandy (maxAmount);
			InvokeRepeating ("RpcCreate", 0, TimeToInstantiate);
		}
	}
	// Update is called once per frame
	void Update () {

	}

	[Server]
	public void RpcInstantiateCandy(int amount)
	{
		if(!isServer){
			return;
		}
		for(int i=0; i<amount; i++)
		{
			
			Object = Instantiate(candy);	
			vector = new Vector3((int)Random.Range(Bgmin_x, BGmax_x), (int)Random.Range(BGmin_y, BGmax_y),0);
			Object.transform.position = vector;
			//Debug.Log (Object);
			NetworkServer.Spawn (Object);
		}
	}
	[Server]
	public void RpcCreate()
	{
		if(!isServer){

			return;
		}
		RpcInstantiateCandy(5);
	}
}
