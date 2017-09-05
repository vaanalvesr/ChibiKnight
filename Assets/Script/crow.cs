using UnityEngine;
using System.Collections;

public class crow : MonoBehaviour {

	public float speed;
	public float damage;
	public float timeCounter;
	private Rigidbody2D body;
	public GameObject hitPrefab;
	
	private life vidaEnemy;

	private Animator anime;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(anime.GetCurrentAnimatorStateInfo(0).IsName("crowIdle")){
			DestroyObject(gameObject);
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

		}
	}
}
