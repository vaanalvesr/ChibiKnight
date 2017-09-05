using UnityEngine;
using System.Collections;

public class Peste : MonoBehaviour {

	public float probabSkillA;
	
	public float probabSkillB;
	
	
	public float timeToSkill;
	
	private float currentTimeToSkill;
	
	public GameObject veneno;
	
	public GameObject crownLauncher;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeToSkill += Time.deltaTime;
		
		if(currentTimeToSkill >= timeToSkill){
			currentTimeToSkill = 0;
			float probab = Random.Range(1,10);
			
			if(probab <= 30){
				GameObject temp = Instantiate(veneno) as GameObject;
				temp.transform.position = transform.position;
			}else if(probab >= 31){
				crownLauncher.GetComponent<crowLauncher>().Launchcrow();
			}
		}
	}
}
