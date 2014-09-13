using UnityEngine;
using System.Collections;

public class splashGUI : MonoBehaviour {
	public GUISkin customSkin = null;

	public void OnGUI(){
		if(customSkin != null)
			GUI.skin = customSkin;

		int buttonWidth = 100;
		int buttonHeight = 100;
		int halfBWidth = buttonWidth/2;
		int halfSWidth = Screen.width/2;
			
		if(GUI.Button(new Rect(halfSWidth-halfBWidth,390,buttonWidth,buttonHeight), "Play"))
		{
			Application.LoadLevel("3D_Voxel");
		}
	}
}
