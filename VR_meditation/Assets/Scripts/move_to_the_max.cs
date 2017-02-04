using UnityEngine;
using System.Collections;

public class move_to_the_max : MonoBehaviour {

    int speed;

    public float max;

    public Camera sound;

    public Vector3 position;

    // Use this for initialization
    void Start () {
        sound = FindObjectOfType<Camera>(); //.GetComponent<spectrum>().sample_max()
        position = this.transform.position;
        speed = 5;

	}
	
	// Update is called once per frame
	void Update () {
        max = sound.GetComponent<spectrum>().sample_max;

        //Vector3 new_position = new Vector3(position.x, position.y, position.z - (max * speed));
        //just speed instead
        Vector3 new_position = new Vector3(position.x, position.y, position.z - (max));


        print(max * speed);
        this.transform.position = new_position;
        position = new_position;

        //this.



    }
}
