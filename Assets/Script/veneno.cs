using UnityEngine;
using System.Collections;

public class veneno : MonoBehaviour {

	public float speed;
	public GameObject hitPrefab;
	public float damage;

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
			vidaEnemy.ApplyDamage(damage);
			coll.gameObject.GetComponent<Player>().veneno = true;
			DestroyObject(gameObject);
		}
	}
}
