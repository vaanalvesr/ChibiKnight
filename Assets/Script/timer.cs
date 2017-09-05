using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	private TextMesh text;
	public float currentTime;

	public float dano;
	public GameObject player;
	private float pontos;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			currentTime += Time.deltaTime;
			text.text = ""+(int)currentTime;
		
		}else{
			pontos = dano / currentTime;
		}
	}
}
