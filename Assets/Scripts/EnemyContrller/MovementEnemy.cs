using UnityEngine;
using System.Collections;
//Isabella
public class MovementEnemy : MonoBehaviour {
    public Transform[] pos;
    Vector3 vector;
    public float speed;
    
    // Use this for initialization
    void Start () {
        vector = pos[Random.Range(0, 6)].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        gameObject.transform.position= Vector3.MoveTowards(gameObject.transform.position, vector, step);
        if(gameObject.transform.position == vector)
        {
            vector = pos[Random.Range(0, 6)].transform.position;
        }
	}  
}
