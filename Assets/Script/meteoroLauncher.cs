using UnityEngine;
using System.Collections;

public class meteoroLauncher : MonoBehaviour {

	public Transform A;

	public Transform B;

	public GameObject prefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LaunchMeteoro(){

		float chance = Random.Range(1, 100);

		GameObject temp = Instantiate(prefab) as GameObject;
		if(chance >= 1 && chance <= 50){
			temp.transform.position = A.position;
		}else{
			temp.transform.position = B.position;
		}
	}
}
