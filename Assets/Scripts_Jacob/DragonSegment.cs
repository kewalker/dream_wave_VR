using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSegment : MonoBehaviour {

	float scale;
	Vector3 change;
	// Use this for initialization
	void Start () {
		scale = 100f;
		change = new Vector3( Random.Range(-1f*scale, 1f*scale) , Random.Range(-1f*scale, 1f*scale), Random.Range(-1f*scale, 1f*scale));
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( change * Time.deltaTime);
		
	}
}
