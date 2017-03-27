using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerate : MonoBehaviour {

	public GameObject star;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
		int star_number = 10000;
		float distance_min = 400;
		float distance_max = 2000;
		
		for ( int i = 0; i < star_number; i++ ) {

			Vector3 angle = new Vector3( Random.Range(-1f, 1f), Random.Range(-1f,1f), Random.Range(-1f,1f) );
			angle.Normalize();

			Vector3 position = angle * distance_min + angle * Random.Range(0, distance_max - distance_min);
			Instantiate( star, position, Quaternion.identity );
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
