using UnityEngine;
using System.Collections;

public class Guerra : MonoBehaviour {
	
	public GameObject MeteoroLauncher;

	public GameObject SwordLauncher;
	
	public float probabSkillA;
	
	public float probabSkillB;
	
	
	public float timeToSkill;
	
	private float currentTimeToSkill;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTimeToSkill += Time.deltaTime;
		
		if(currentTimeToSkill >= timeToSkill){
			currentTimeToSkill = 0;
			float probab = Random.Range(1,10);
			
			if(probab == 1){
				MeteoroLauncher.GetComponent<meteoroLauncher>().LaunchMeteoro();

			}else if(probab > 1){
				SwordLauncher.GetComponent<swordLauncher>().LaunchSword();
			}
		}
		
	}
}
