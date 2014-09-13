using UnityEngine;
using System.Collections;

public class MeleeSys : MonoBehaviour {
	public int Damage = 100;
	public float Distance;
	float MaxDistance = 10;

	void Update(){
		if(Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit))
				{
					Distance = hit.distance;
				if(Distance < MaxDistance){
					hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
				}
			}
		}	
	}
}

