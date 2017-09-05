using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private bool inEnemy;
	public float speed;
	private Rigidbody2D body;
	public LayerMask isGround;
	public LayerMask isEnemy;
	public float jumpForce;
	public float movimentX;

	public float cdDefensor;
	public float cdArqueiro;
	public float cdAlquimista;
	public float cdMago;

	private float currentcdDefensor;
	private float currentcdArqueiro;
	private float currentcdAlquimista;
	private float currentcdMago;
	private float currentTimeToShootArrow;
	private float currentTimeToShootBomb;
	private bool canShootArrow;
	private bool canShootBomb;
	private float randomArrow;
	private float shootNumberArrow;
	private float shootNumberBomb;


	private bool canUsecdDefensor;
	private bool canUsecdArqueiro;
	private bool canUsecdAlquimista;
	private bool canUsecdMago;

	public GameObject Defensor;
	public GameObject Arqueiro;
	public GameObject Alquimista;
	public GameObject Mago;

	public float maxLife;
	private float currentLife;
	public float basicDamage;
	public float criticoDamage;
	public float defenseDamage;


	//CONTROLE DAS BARRAS DE CD
	public Transform arrowBar;
	public Transform shieldBar;
	public Transform mageBar;
	public Transform bombBar;

	private float maxScaleArrowBarX;
	private float maxScaleShieldBarX;
	private float maxScaleMageBarX;
	private float maxScaleBombBarX;

	private float currentArrowBarX;
	private float currentShieldBarX;
	private float currentMageBarX;
	private float currentBombBarX;

	private float defenseCount;

	private Animator anime;

	public GameObject hitPrefab;

	public Transform swordHit;

	public GameObject Enemy;


	public bool slow;

	private float currentSlowTime;
	
	public bool charm;

	private float currentCharmTime;

	public bool veneno;
	
	private float currentVenenoTime;

	public bool defense;

	private enum  SKILL
	{
		DEFENSOR,
		ARQUEIRO,
		ALQUIMISTA,
		MAGO
	}

	// Use this for initialization
	void Start ()
	{
		defenseCount = 0;
		body = GetComponent<Rigidbody2D> ();
		currentLife = maxLife;
		randomArrow = 0;
		shootNumberArrow = 0;
		shootNumberBomb = 0;
		anime = GetComponent<Animator> ();

		maxScaleArrowBarX = arrowBar.localScale.x;
		maxScaleShieldBarX = shieldBar.localScale.x;
		maxScaleMageBarX = mageBar.localScale.x;
		maxScaleBombBarX = bombBar.localScale.x;

		currentArrowBarX = maxScaleArrowBarX;
		currentShieldBarX = maxScaleShieldBarX;
		currentMageBarX = maxScaleMageBarX;
		currentBombBarX = maxScaleBombBarX;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool walk = false;

		defense = false;

		float movimentX = Input.GetAxis ("Horizontal");

		float s;

		if(!charm){
			if(!veneno){
				if(!slow){
					s = speed;
				}else{
					s = speed / 3;
					currentSlowTime += Time.deltaTime;
					if (currentSlowTime >= 4) {
						currentSlowTime = 0;
						slow = false;
					}
				}
			}else{
				s = speed;
				movimentX *= -1;
				currentVenenoTime += Time.deltaTime;
				if(currentVenenoTime >= 12){
					currentVenenoTime = 0;
					veneno = false;
				}
			}
		}else{
			movimentX = 1;
			s = speed / 4;
			currentCharmTime += Time.deltaTime;
			if (currentCharmTime >= 5) {
				currentCharmTime = 0;
				charm = false;
			}
		}

		if(transform.position.x <= -6.36f){
			if(movimentX > 0){
				transform.Translate (new Vector3 (movimentX * s, 0, 0) * Time.deltaTime);
			}
		}else{
			transform.Translate (new Vector3 (movimentX * s, 0, 0) * Time.deltaTime);
		}

		if (movimentX != 0) {
			walk = true;
		}

		if (Input.anyKey) {
			if (Input.GetButtonDown ("Attack")) {
				anime.SetTrigger ("Attack");

			} else if (Input.GetButton ("Defense")) {
				defenseCount++;
				defense = true;

			} else if (Input.GetButtonDown ("Defensor")) {
				if (canUsecdDefensor) {
					GameObject temp = Instantiate(Defensor) as GameObject;
					temp.transform.position = transform.position;
					GetComponent<life>().Heal();
					increaseCD (SKILL.DEFENSOR);
					canUsecdDefensor = false;
					currentcdDefensor = 0;
				}
			} else if (Input.GetButtonDown ("Arqueiro")) {
				if (canUsecdArqueiro && !canShootArrow) {
					canShootArrow = true;
					increaseCD (SKILL.ARQUEIRO);
					currentcdArqueiro = 0;
				}
			} else if (Input.GetButtonDown ("Alquimista")) {
				if (canUsecdAlquimista) {
					GameObject temp = Instantiate (Alquimista) as GameObject;
					temp.transform.position = transform.position;
					increaseCD (SKILL.ALQUIMISTA);
					canUsecdAlquimista = false;
					currentcdAlquimista = 0;
				}
			} else if (Input.GetButtonDown ("Mago")) {
				if (canUsecdMago) {
					GameObject temp = Instantiate (Mago) as GameObject;
					temp.transform.position = transform.position;
					increaseCD (SKILL.MAGO);
					canUsecdMago = false;
					currentcdMago = 0;
				}
			}
			 
		} else {
			defenseCount = 0;
		}

		anime.SetFloat ("Defense", defenseCount);
		anime.SetBool ("walk", walk);

		countCD ();

		shootArrow ();
	}



	void shootArrow ()
	{
		if (canShootArrow) {
			if (randomArrow == 0) {
				randomArrow = Random.Range (0.2f, 0.3f);
			}

			float randomY = Random.Range (-1.5f, 1f);

			currentTimeToShootArrow += Time.deltaTime;
			if (currentTimeToShootArrow >= randomArrow) {
				currentTimeToShootArrow = 0;
				randomArrow = 0;
				GameObject temp = Instantiate (Arqueiro) as GameObject;
				temp.transform.position = new Vector3 (transform.position.x, transform.position.y + randomY, transform.position.z);
				shootNumberArrow++;
			}

			if (shootNumberArrow == 20) {
				shootNumberArrow = 0;
				canShootArrow = false;
				canUsecdArqueiro = false;
			}
		}
	}


	void increaseCD (SKILL s)
	{
		if (s != SKILL.ALQUIMISTA) {
			currentcdAlquimista -= 3;
			if (currentcdAlquimista < 0) {
				currentcdAlquimista = 0;
			}
		}
		if (s != SKILL.ARQUEIRO) {
			
			currentcdArqueiro -= 3;
			if (currentcdArqueiro < 0) {
				currentcdArqueiro = 0;
			}
			
		}
		if (s != SKILL.DEFENSOR) {
			
			currentcdDefensor -= 3;
			if (currentcdDefensor < 0) {
				currentcdDefensor = 0;
			}
		}
		if (s != SKILL.MAGO) {
			
			currentcdMago -= 3;
			if (currentcdMago < 0) {
				currentcdMago = 0;
			}
		}
	}

	void countCD ()
	{
		if (!canUsecdDefensor) {
			currentcdDefensor += Time.deltaTime;
			if (currentcdDefensor >= cdDefensor) {
				currentcdDefensor = cdDefensor;
				canUsecdDefensor = true;
			}
			currentShieldBarX = currentcdDefensor * maxScaleShieldBarX / cdDefensor;
			shieldBar.localScale = new Vector3 (currentShieldBarX, shieldBar.localScale.y, shieldBar.localScale.z);
		}

		if (!canUsecdArqueiro) {
			currentcdArqueiro += Time.deltaTime;
			if (currentcdArqueiro >= cdArqueiro) {
				currentcdArqueiro = cdArqueiro;
				canUsecdArqueiro = true;
			}

			currentArrowBarX = currentcdArqueiro * maxScaleArrowBarX / cdArqueiro;
			arrowBar.localScale = new Vector3 (currentArrowBarX, arrowBar.localScale.y, arrowBar.localScale.z);
		}

		if (!canUsecdAlquimista) {
			currentcdAlquimista += Time.deltaTime;
			if (currentcdAlquimista >= cdAlquimista) {
				currentcdAlquimista = cdAlquimista;
				canUsecdAlquimista = true;
			}

			currentBombBarX = currentcdAlquimista * maxScaleBombBarX / cdAlquimista;
			bombBar.localScale = new Vector3 (currentBombBarX, bombBar.localScale.y, bombBar.localScale.z);
		}

		if (!canUsecdMago) {
			currentcdMago += Time.deltaTime;
			if (currentcdMago >= cdMago) {
				currentcdMago = cdMago;
				canUsecdMago = true;
			}

			currentMageBarX = currentcdMago * maxScaleMageBarX / cdMago;
			mageBar.localScale = new Vector3 (currentMageBarX, mageBar.localScale.y, mageBar.localScale.z);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			inEnemy = true;
			if (Enemy == null) {
				Enemy = coll.gameObject;
			}
		}
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.tag == "Enemy" && Enemy != null) {
			if (Input.GetButtonDown ("Attack") && !anime.GetCurrentAnimatorStateInfo (0).IsName ("Blend Tree")) {
				GameObject temp = Instantiate (hitPrefab) as GameObject;
				temp.transform.position = swordHit.position;
				life vidaEnemy = coll.gameObject.GetComponent<life> ();
				vidaEnemy.ApplyDamage (basicDamage);
			}
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			Enemy = null;
			inEnemy = false;
		}
	}
}
