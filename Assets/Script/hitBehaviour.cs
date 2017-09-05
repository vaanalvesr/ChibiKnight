using UnityEngine;
using System.Collections;

public class hitBehaviour : MonoBehaviour {


	public Animator anime;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anime.GetCurrentAnimatorStateInfo(0).IsName("HitIdle")){
			DestroyObject(gameObject);
		}
	}
}
