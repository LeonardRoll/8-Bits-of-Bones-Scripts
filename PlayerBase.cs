using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {
	//Attributes
	private Vector3 RespawnPoint;
	private double maxHealth = 100;
	private double currHealth;
	public int score;
	private int SetWep;
	public GUIText guiScore;

	//Objects
	public GameObject Sword,Bow,Arm;

	// Use this for initialization
	void Start () {
		RespawnPoint = this.transform.position;
		currHealth = 100;
		guiScore.text = "Score: " + score;
		score = 0;
		SetWep = 1; //Default
	}

	void wepSwitch(){
		if(SetWep == 1){
			SetWep = 2;
		}
		else if(SetWep == 2){
			SetWep = 1;
		}
	}
	
	//Weapon Set Up
	void Set_Weapon(int type){
		if(type == 1){
			//switch to sword
			Sword.SetActive(true);
		}
		else if(type == 2){
			//set to bow
			Sword.SetActive(false);
		}
		//set weapon code
	}

	public void is_Hit(int damage){
		currHealth = currHealth - damage;
	}

	public bool check_Dead(){
		if(currHealth <= 0){
			return true;
		}
		else {
			return false;
				}
	}

	public void AddScore(int Amount){
		score += Amount;
		guiScore.text = "Score: " + score;
	}

	void OnTriggerEnter(Collider thisGhost){
		if(thisGhost.gameObject.tag == "Ghost"){
			is_Hit(10);
			Destroy(thisGhost.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		Messenger<double,double>.Broadcast("update health",currHealth,maxHealth);
		Debug.Log(currHealth);
		if(check_Dead()){
			//Destroy (gameObject); //Causes Lag
			Application.LoadLevel("Splash Screen Scene");
		}
		if(Input.GetKeyDown(KeyCode.F)){
			Debug.Log("Switching");
			wepSwitch();
			Set_Weapon(SetWep);
		}

		if(Input.GetMouseButton(0)){

		}
	}
}
