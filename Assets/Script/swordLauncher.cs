using UnityEngine;
using System.Collections;

public class swordLauncher : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LaunchSword(){
		
		float chance = Random.Range(1, 100);
		
		GameObject temp = Instantiate(prefab) as GameObject;
		temp.transform.position = transform.position;
	}
}
