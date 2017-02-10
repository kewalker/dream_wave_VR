using UnityEngine;
using System.Collections;

public class set_parent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.parent = GameObject.FindGameObjectWithTag("master_cube").transform;
        Destroy(GetComponent<set_parent>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
