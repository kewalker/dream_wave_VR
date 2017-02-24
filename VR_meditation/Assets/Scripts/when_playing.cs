using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class when_playing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying)
            print("In player or playmode");

    }
}

