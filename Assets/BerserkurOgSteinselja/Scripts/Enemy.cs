using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

	public Transform[] targets;
	[HideInInspector]
	public Transform target;
	public int MoveSpeed = 2;
	public int MaxDist = 500;
	public int MinDist = 1;
	[HideInInspector]
	public bool killable = false;
	[HideInInspector]
    public float distanceFromTarget;

	void Update()
	{
		if(targets.Length > 0){
			target = targets[0];
			foreach(Transform t in targets){
				if(Vector3.Distance(transform.position, t.position) < Vector3.Distance(transform.position, target.position)){
					target = t;
				}
			}
			transform.LookAt(target);
			distanceFromTarget = Vector3.Distance(transform.position, target.position);
			//transform.LookAt(steinselja);

			if (distanceFromTarget <= MaxDist &&
				distanceFromTarget >= MinDist)
			{
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Player" || other.collider.tag == "Player2"){
			other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * 200 ,100,transform.forward.z * 200), ForceMode.Impulse);
			other.gameObject.GetComponent<PlayerController>().hp -=1 ;
		}
	}
}
