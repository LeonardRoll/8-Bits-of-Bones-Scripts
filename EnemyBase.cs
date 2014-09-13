using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {
	
	public GameObject Player;
	public GameObject World;
	public PlayerBase PlayerScript;
	public World WorldScript;
	private int movespeed;
	private float health = 100;
	private int Max_Distance;
	private int travelDistance;

	void ApplyDamage(int TheDamage){
		health -= TheDamage;
	}
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		World = GameObject.Find ("World");
		PlayerScript = Player.GetComponent<PlayerBase>();
		WorldScript = World.GetComponent<World>();
		movespeed = 4;
		Max_Distance = 20;
		travelDistance = 0;
	}

	// Update is called once per frame
	void Update () {
		if(health <= 0){
			PlayerScript.AddScore(10);
			WorldScript.Addkill();
			Dead();
		}
		if(this.transform.position.y < -10){
			Dead();
		}

		if(Vector3.Distance(transform.position,Player.transform.position) <= Max_Distance){
			transform.LookAt(Player.transform);
			transform.position += transform.forward*movespeed*Time.deltaTime;
		}
		transform.position += transform.forward*movespeed*Time.deltaTime;
			travelDistance++;
		if(travelDistance >= 100){
				transform.Rotate(Vector3.up,Random.Range(0,360));
				travelDistance = 0;
			}
	}

	void Dead(){
		Destroy (gameObject);
	}		
}
