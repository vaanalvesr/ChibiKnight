using UnityEngine;
using System.Collections;

public class WarriorSpawner : MonoBehaviour {

	public float timeToSpawn;
	private float currentTimeToSpawn;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		currentTimeToSpawn += Time.deltaTime;
		if(currentTimeToSpawn >= timeToSpawn){
			currentTimeToSpawn = 0;
			GameObject temp = Instantiate(prefab) as GameObject;
			temp.transform.position = transform.position;
		}
	}
}
