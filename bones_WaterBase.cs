using UnityEngine;
using System.Collections;

public class bones_WaterBase : MonoBehaviour {
	
	public float waterLevel;
	GameObject water;
	GameObject player;
	public bool isUnderWater;
	private Color normalColor;
	private Color underWaterColor;
	
	// Use this for initialization
	void Start () {
		normalColor = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		underWaterColor = new Color (0.0f, 0.0f, 1.0f, 1.0f);
		player = GameObject.Find ("Bones_Anim");
		water = GameObject.Find("waterObject");
		waterLevel = water.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position.y) != waterLevel) {
			isUnderWater = transform.position.y< waterLevel;
			if(isUnderWater)
			{
				setUnderWater();
			}
			if(!isUnderWater)
			{
				setNormal();
			}
		}
	}
	void setUnderWater()
	{
		RenderSettings.fogColor = underWaterColor;
		RenderSettings.fogDensity = 0.2f;
	}
	void setNormal()
	{
		RenderSettings.fogColor = normalColor;
		RenderSettings.fogDensity = 0.0002f;
	}
}
