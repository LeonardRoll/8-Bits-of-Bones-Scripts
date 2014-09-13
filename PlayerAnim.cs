using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {
	public Transform RightHand;	

	void Start(){
		animation["SwingSword"].layer = 5;
		animation["SwingSword"].speed = 2.0f;
		animation["SwingSword"].AddMixingTransform(RightHand);
		animation["Walk"].speed = 4.0f;
	}	

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W)){
			animation.Play("Walk");
		}

		if(Input.GetKeyUp(KeyCode.W)){
			animation.Stop("Walk");
		}

		if(Input.GetMouseButtonDown(0)){
			animation.Blend("SwingSword");
			//animation.Play("SwingSword");
		}
	}
}
