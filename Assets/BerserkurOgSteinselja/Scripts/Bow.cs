using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Bow : MonoBehaviour {

	public Transform Arrow;
	public Player player;
	private bool _bowButtonDown;
	private Vector3 _aimVector;
    private float timeNextShot;
    public float shotInterval;

    // Use this for initialization
    void Start () {
		player = ReInput.players.GetPlayer(1);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		ProcessInput();
	}

	private void GetInput(){
		_bowButtonDown = player.GetButton("Fire");
	}

	private void ProcessInput(){
		if(_bowButtonDown && Time.time >= timeNextShot){
			Instantiate(Arrow,transform.position, transform.rotation);
			timeNextShot = Time.time + shotInterval;
		}
	}
}
