using UnityEngine;
using System.Collections;

public class slow_move : MonoBehaviour {

    public Vector3 position;

    int speed;

	// Use this for initialization
	void Start () {
        position = gameObject.transform.position;

        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {

        position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        this.transform.position = position;

	}
}
