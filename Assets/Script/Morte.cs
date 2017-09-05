using UnityEngine;
using System.Collections;

public class Morte : MonoBehaviour {
	
	public GameObject foiceGiratoria;

	public GameObject foice;

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
			
			if(probab <= 3){
				GameObject temp = Instantiate(foiceGiratoria) as GameObject;
				temp.transform.position = transform.position;

			}else if(probab > 3){

				GameObject temp = Instantiate(foice) as GameObject;
				temp.transform.position = transform.position;
			}
		}
		
	}
}
