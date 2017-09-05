using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour {

	public float speed;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player == null){
			transform.Translate(Vector3.left * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			player = coll.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if(coll.tag == "Player"){
			player = null;
		}
	}
}
