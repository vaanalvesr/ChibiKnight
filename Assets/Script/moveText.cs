using UnityEngine;
using System.Collections;

public class moveText : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
		DestroyObject(gameObject);
	}
}
