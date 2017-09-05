using UnityEngine;
using System.Collections;

public class frango : MonoBehaviour {

	public float speed;
	public float damage;
	public float timeCounter;
	private Rigidbody2D body;
	public GameObject hitPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gameObject.tag != "Bomb"){
			transform.Translate(new Vector3(-1*speed * Time.deltaTime, 0 , 0));
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			life vidaEnemy = coll.gameObject.GetComponent<life>();
			coll.gameObject.GetComponent<Player>().charm = true;
			vidaEnemy.ApplyDamage(damage);
			DestroyObject(gameObject);
		}
	}
}
