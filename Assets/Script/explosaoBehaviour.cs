﻿using UnityEngine;
using System.Collections;

public class explosaoBehaviour : MonoBehaviour {
	public Animator anime;

	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anime.GetCurrentAnimatorStateInfo(0).IsName("explosaoIdle")){
			DestroyObject(gameObject);
		}
	}
}
