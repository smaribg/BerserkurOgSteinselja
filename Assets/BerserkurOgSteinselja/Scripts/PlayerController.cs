using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerController : MonoBehaviour {

	public int playerId;

	public float movementSpeed = 5.0f;
	private Player player;
	private Vector3 moveVector;

	public int hp = 3;

	public Text HealthPoints;

	private Vector3 _aimVector;
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		ProcessInput();
		checkIfDead();
		// if(playerId == 1)
//			HealthPoints.text = "Health points:" + hp;
	}
	void checkIfDead(){
		if(hp == 0){
			gameObject.GetComponent<Collider>().enabled = false;
		}
	}

	private void GetInput() {
		moveVector.x = player.GetAxis("Move Horizontal");
		moveVector.z = player.GetAxis("Move Vertical");

		if(playerId == 1){
			_aimVector.x = player.GetAxis("Aim Horizontal");
			_aimVector.z = player.GetAxis("Aim Vertical");
		}
	}

	private void ProcessInput() {
		if(moveVector.x != 0.0f || moveVector.z != 0.0f){
			transform.position = (transform.position + moveVector * movementSpeed * Time.deltaTime);
			if(playerId == 0)
				transform.rotation = Quaternion.LookRotation(moveVector);
		}

		if(playerId == 1){
			if(_aimVector.x != 0.0f || _aimVector.z != 0.0f){
				transform.rotation = Quaternion.LookRotation(_aimVector);
			}
		}
	}
}
