using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Ghost;
	public GameObject World;
	public PlayerBase PlayerScript;
	public World WorldScript;
	private float health = 100;
	private int Max_Minions = 10;
	private float SpawnTimer = 180; //every 3 Minutes
	
	void ApplyDamage(int TheDamage){
		health -= TheDamage;
	}
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		World = GameObject.Find ("World");
		PlayerScript = Player.GetComponent<PlayerBase>();
		WorldScript = World.GetComponent<World>();
		SpawnGhost();
	}

	void SpawnGhost(){
		for(int i = 0 ; i <= Max_Minions ; i++){
			Instantiate(Ghost,RandomAround(transform.position,10,100),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
				PlayerScript.AddScore(100);
				WorldScript.ReduceSpawner();
				Dead();
			}
		if(this.transform.position.y < -10){
			WorldScript.ReduceSpawner();
			Dead();
		}
		if(SpawnTimer > 0)
			SpawnTimer -= Time.deltaTime;
		if(SpawnTimer <= 0){
			SpawnGhost();
			SpawnTimer = 60;
		}
	}
	
	void Dead(){
		Destroy (gameObject);
	}	

	public Vector3 RandomAround (Vector3 center, float minDist,float maxDist){
		Vector3 v3 = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward;
		v3 = v3 * Random.Range(minDist, maxDist);
		return center + v3; 
	}
}

