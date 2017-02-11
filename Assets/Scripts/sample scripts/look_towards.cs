using UnityEngine;
using System.Collections;

public class look_towards : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the camera every frame so it keeps looking at the target 
        //normal
        //transform.LookAt(target);

        //fix the rotate when look orientation reversed
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
    }
}
