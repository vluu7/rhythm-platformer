using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

/*
 * First Try of Koreographer Event Handler Script.
 */

public class EventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void FireEventDebugLog(KoreographyEvent koreoEvent) 
    {
        Debug.Log("Koreography Event Fired.");
    }



}
