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

    // Print a message to the console once Koreographer Event is fired off
    void FireEventDebugLog(KoreographyEvent koreoEvent) 
    {
        Debug.Log("Koreography Event Fired.");
    }

}
