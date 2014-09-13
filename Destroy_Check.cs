using UnityEngine;
using System.Collections;

public class Destroy_Check : MonoBehaviour {

	public GameObject self;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y < -10)
			Destroy (self);
	}
}
