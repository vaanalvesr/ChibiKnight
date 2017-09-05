using UnityEngine;
using System.Collections;

public class slow : MonoBehaviour {

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
			foreach (ContactPoint2D contact in coll.contacts) {
				if(hitPrefab!= null){
					GameObject temp = Instantiate(hitPrefab) as GameObject;
					temp.transform.position = contact.point;
				}
			}
			life vidaEnemy = coll.gameObject.GetComponent<life>();
			vidaEnemy.ApplyDamage(damage);
			coll.gameObject.GetComponent<Player>().slow = true;
			DestroyObject(gameObject);
		}
	}
}
