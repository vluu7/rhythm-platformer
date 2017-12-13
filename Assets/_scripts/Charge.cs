using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {
	public float barDisplay; //current progress
	//public static Color color;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,40);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	void OnGUI() {
		//draw the background:
		//GUI.backgroundColor = Color.blue;
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		//GUI.color = Color.blue;

		//draw the filled-in part:
		//GUI.backgroundColor = Color.blue;
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	void FixedUpdate() {
		if (barDisplay < 1) {
			barDisplay = barDisplay + 0.00014f;
			//Debug.Log (barDisplay);		
			if (Input.GetKeyDown (KeyCode.O)) {
				barDisplay = barDisplay - 200.0f / 1000.0f;
				if (barDisplay < 0.0) {
					barDisplay = 0;
				}
			}
		}
	}
}