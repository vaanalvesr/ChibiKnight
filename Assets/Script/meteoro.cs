using UnityEngine;
using System.Collections;

public class meteoro : MonoBehaviour {

	public float speed;

	
	private bool visto;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(-1 * speed * Time.deltaTime, -1 * speed * Time.deltaTime, transform.position.z));
	}

	
	void OnBecameInvisible() {
		if(visto)
			DestroyObject(gameObject);
	}
	void OnBecameVisible() {
		visto = true;
	}
}
