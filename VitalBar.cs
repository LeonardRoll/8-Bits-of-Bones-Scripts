using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {

	private bool isPlayerHealthbar; //checks if its player
	private double maxBarLength;	//maximum healthbar length
	private double currBarLength; //current healthbar length
	private GUITexture display;

	// Use this for initialization
	void Start () {
		isPlayerHealthbar = true;
		display = gameObject.GetComponent<GUITexture>();
		maxBarLength = (double)display.pixelInset.width;
		OnEnable();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable(){
		Messenger<double,double>.AddListener("update health",ChangeHealthBarSize);
	}

	public void OnDisable(){
		Messenger<double,double>.RemoveListener("update health",ChangeHealthBarSize);
	}

	public void ChangeHealthBarSize(double currentHealth,double maxHealth){
		//Debug.Log("Event Heard" + currBarLength + "Health:" + currentHealth);
		//if(currBarLength)
		currBarLength = (currentHealth / maxHealth) * maxBarLength;	//this calculates the current bar length
		display.pixelInset= new Rect(display.pixelInset.x,display.pixelInset.y,
			                             (float)currBarLength,display.pixelInset.height);
	}

	//sets the health bar to the player
	public void SetPlayerHealth(bool check){
		isPlayerHealthbar = check;
	}
}
