using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {

	public float speed;
	public float damage;
	public float timeCounter;
	private Rigidbody2D body;
	public GameObject hitPrefab;
	
	private life vidaEnemy;
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
			foreach (ContactPoint2D contact in coll.contacts) {
				GameObject temp = Instantiate(hitPrefab) as GameObject;
				temp.transform.position = contact.point;
			}
			if(!coll.gameObject.GetComponent<Player>().defense){
				vidaEnemy = coll.gameObject.GetComponent<life>();
				vidaEnemy.ApplyDamage(damage);
			}

			DestroyObject(gameObject);
		}
	}
}
