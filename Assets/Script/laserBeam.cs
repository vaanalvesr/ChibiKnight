using UnityEngine;
using System.Collections;

public class laserBeam : MonoBehaviour {

	private Animator anime;
	public GameObject hitPrefab;
	public float damage;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anime.GetCurrentAnimatorStateInfo(0).IsName("LaserIdle")){
			DestroyObject(gameObject);
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
		}
	}
}
