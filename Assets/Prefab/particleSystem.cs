using UnityEngine;
using System.Collections;

public class particleSystem : MonoBehaviour {
	private float count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if(count >= 2.0f){
			DestroyObject(gameObject);
		}
	}
}
