using UnityEngine;
using System.Collections;

public class up_n_down : MonoBehaviour {

    public int intensity;
    public Vector3 position;

	// Use this for initialization
	void Start () {
        intensity = 2;
        position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 new_position = new Vector3(position.x, position.y + (Mathf.Sin(Time.time) * intensity), position.z);
        this.transform.position = new_position;
	}
}
