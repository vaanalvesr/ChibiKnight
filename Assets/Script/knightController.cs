using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour {

	public GameObject[] cavaleiras;

	private int count = 0;

	public float currentTimeToSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeToSpawn += Time.deltaTime;

		if(count <= 3){
			if(currentTimeToSpawn >= 30f){
				cavaleiras[count].SetActive(true);
				currentTimeToSpawn = 0;
			}
		}
	}
}
