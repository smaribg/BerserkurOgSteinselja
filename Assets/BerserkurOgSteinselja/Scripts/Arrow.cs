using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private CapsuleCollider _collider;
	private bool moving = true;
	private Vector3 scale;
	// Use this for initialization
	void Start () {
		scale = transform.localScale;
		_collider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(moving){
			transform.position = (transform.position + transform.up * 20 * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			transform.SetParent(other.transform);
			moving = false;
			_collider.enabled = false;
		}else if(other.tag == "Enemy"){
			other.GetComponent<Enemy>().killable = true;
			other.GetComponent<Renderer>().material.SetColor("_Color",Color.yellow);
			other.GetComponent<Rigidbody>().AddForce(new Vector3(transform.up.x * 100 ,100,transform.up.z * 100), ForceMode.Impulse);
		}else if(other.tag != "Player2"){
			Destroy(gameObject);
		}
	}
}
