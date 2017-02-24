using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
