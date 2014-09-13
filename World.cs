using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	
	public GameObject chunk;
	public GameObject[,,] chunks;
	public GameObject Tree;
	public GameObject Spawners;
	public GameObject Player;

	public PlayerBase PlayerScript;
	public int chunkSize;
	public int KillCount;
	public int SpawnersRemaining;
	public Vector3 PlayerPosition;

	public GUIText guiKillCount;
	public GUIText guiSpawnerCount;

	public byte[,,] data;
	public int worldX;
	public int worldY;
	public int worldZ;
	public int TreeCount;
	public int SpawnerCount;
	private double Timer; 
	
	// Use this for initialization
	void Start () {
		PlayerScript = Player.GetComponent<PlayerBase>();
		PlayerPosition = Player.transform.position;
		KillCount = 0;
		data = new byte[worldX,worldY,worldZ];
		
		for (int x=0; x<worldX; x++){
			for (int z = 0; z < worldZ; z++){
				int stone=PerlinNoise(x,0,z,10,3,1.2f);
				stone+= PerlinNoise(x,300,z,20,4,0)+10;
				int dirt=PerlinNoise(x,100,z,50,3,0)+1;
				
				for (int y=0; y<worldY; y++){
					if(y<=stone){
						data[x,y,z]=1;
					} else if(y<=dirt+stone){
						data[x,y,z]=2;
					}
				}
			}
		}
		
		
		chunks=new GameObject[Mathf.FloorToInt(worldX/chunkSize),Mathf.FloorToInt(worldY/chunkSize),Mathf.FloorToInt(worldZ/chunkSize)];
		
		for (int x=0; x<chunks.GetLength(0); x++){
			for (int y=0; y<chunks.GetLength(1); y++){
				for (int z=0; z<chunks.GetLength(2); z++){
					
					chunks[x,y,z]= Instantiate(chunk,new Vector3(x*chunkSize,y*chunkSize,z*chunkSize),new Quaternion(0,0,0,0)) as GameObject;
					Chunk newChunkScript= chunks[x,y,z].GetComponent("Chunk") as Chunk;
     newChunkScript.worldGO=gameObject;
     newChunkScript.chunkSize=chunkSize;
     newChunkScript.chunkX=x*chunkSize;
     newChunkScript.chunkY=y*chunkSize;
     newChunkScript.chunkZ=z*chunkSize;
      
    }
   }
  }
		Spawn_Tree(TreeCount);
		Spawn_Spawners(SpawnerCount);
		SpawnersRemaining = SpawnerCount;
		guiKillCount.text = "Kills: " + KillCount;
		guiSpawnerCount.text = "Spawners: " + 
			SpawnersRemaining + " of " + SpawnerCount;
 }
  
 int PerlinNoise(int x,int y, int z, float scale, float height, float power){
  float rValue;
  rValue=Noise.Noise.GetNoise (((double)x) / scale, ((double)y)/ scale, ((double)z) / scale);
  rValue*=height;
   
  if(power!=0){
   rValue=Mathf.Pow( rValue, power);
  }
   
  return (int) rValue;
 }
  
  
 // Update is called once per frame
 void Update () {
		//if(PlayerScript.check_Dead()){
			//Instantiate(Player,PlayerPosition,Quaternion.identity);
		//}
 }
  
public void Addkill(){
		KillCount++;
		guiKillCount.text = "Kills: " + KillCount;
	}

public void ReduceSpawner(){
		SpawnersRemaining--;
		guiSpawnerCount.text = "Spawners: " + 
			SpawnersRemaining + " of " + SpawnerCount;
	}

 public byte Block(int x, int y, int z){
   
  if( x>=worldX || x<0 || y>=worldY || y<0 || z>=worldZ || z<0){
   return (byte) 1;
  }
   
  return data[x,y,z];
 }
	public void Spawn_Tree(int amount){
		for(int i = 0; i < amount; i++)
		{
			Instantiate(Tree,RandomAround(Player.transform.position,10,250),Quaternion.identity);
		}
	}

	public void Spawn_Spawners(int amount){
		for(int i = 0; i < amount; i++)
		{
			Instantiate(Spawners,RandomAround(Player.transform.position,10,250),Quaternion.identity);
		}
	}

	public Vector3 RandomAround (Vector3 center, float minDist,float maxDist){
		Vector3 v3 = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward;
		v3 = v3 * Random.Range(minDist, maxDist);
		return center + v3; 
	}
}