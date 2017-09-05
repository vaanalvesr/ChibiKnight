using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	public float speed;
	public float damage;
	public float timeCounter;
	private Rigidbody2D body;
	public GameObject hitPrefab;

	private life vidaEnemy;
	// Use this for initialization
	void Start () {
		timeCounter = 0;
		if(gameObject.tag == "Bomb"){
			body = GetComponent<Rigidbody2D>();
			body.AddForce(new Vector2(1 * speed,1 * speed));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gameObject.tag != "Bomb" && gameObject.tag != "Bomb"){
			transform.Translate(new Vector3(1*speed * Time.deltaTime, 0 , 0));
		}
	}

	
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Enemy"){
			foreach (ContactPoint2D contact in coll.contacts) {
				GameObject temp = Instantiate(hitPrefab) as GameObject;
				temp.transform.position = contact.point;
			}
				life vidaEnemy = coll.gameObject.GetComponent<life>();
				vidaEnemy.ApplyDamage(damage);
			DestroyObject(gameObject);
		}
	}
}
