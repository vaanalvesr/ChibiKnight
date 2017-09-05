using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {

	public float MaxLife;
	private float currentLife;


	public GameObject Tobjeto;
	private TextMesh text;


	public Transform[] lifeBar;
	private int currentLifeBar;
	private Transform actualLifeBar;
	private float startSizeLifeBar;
	private float currentSizeLifeBar;
	public float heal;


	public timer Tempo;
	// Use this for initialization
	void Start () {
		currentLife = MaxLife;
		currentLifeBar = 0;
		actualLifeBar = lifeBar[currentLifeBar];
		startSizeLifeBar = actualLifeBar.localScale.x;
		currentSizeLifeBar = startSizeLifeBar;
	}

	// Update is called once per frame
	void Update () {
		if(currentLife <= 0){
			DestroyObject(gameObject);
		}
	
	}

	public void ApplyDamage(float damage){
		currentLife -= damage;
		currentSizeLifeBar = currentLife * startSizeLifeBar / MaxLife;
		if(Tobjeto != null){launchText(damage);}
		gameObject.GetComponent<Animator>().SetTrigger("Hit");
		if(currentSizeLifeBar < 0){
			currentSizeLifeBar = 0;
		}
		actualLifeBar.localScale = new Vector3(currentSizeLifeBar, actualLifeBar.localScale.y, actualLifeBar.localScale.z);
		if(gameObject.tag != "Player"){
			Tempo.dano += damage;
		}
	}

	public void Heal(){
		currentSizeLifeBar += heal;
		if(currentSizeLifeBar > startSizeLifeBar){
			currentSizeLifeBar = startSizeLifeBar;
		}
		actualLifeBar.localScale = new Vector3(currentSizeLifeBar, actualLifeBar.localScale.y, actualLifeBar.localScale.z);
	}

	void launchText(float damage){
		GameObject temp = Instantiate(Tobjeto) as GameObject;
		temp.transform.position = transform.position;
		text = temp.GetComponent<TextMesh>();
		text.text = ""+damage;
	}
	
}
