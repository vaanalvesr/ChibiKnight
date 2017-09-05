using UnityEngine;
using System.Collections;

public class Fome : MonoBehaviour {
	public float probabSkillA;
	
	public float probabSkillB;
	
	
	public float timeToSkill;

	private float currentTimeToSkill;

	public GameObject slow;

	public GameObject frango;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTimeToSkill += Time.deltaTime;
		
		if(currentTimeToSkill >= timeToSkill){
			currentTimeToSkill = 0;
			float probab = Random.Range(1,10);
			
			if(probab < 5){
				GameObject temp = Instantiate(frango) as GameObject;
				temp.transform.position = transform.position;
			}else if(probab >5){
				GameObject prefab = Instantiate(slow) as GameObject;
				prefab.transform.position = transform.position;
				
			}
		}
		
	}
}
