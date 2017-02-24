using UnityEngine;
using System.Collections;

public class move_to_the_max : MonoBehaviour {

    public float speed;
    public int offset;
    public float max;

    public Camera sound;

    public Vector3 position;

    // Use this for initialization
    void Start () {
        sound = FindObjectOfType<Camera>(); //.GetComponent<spectrum>().sample_max()
        position = this.transform.position;
        speed = 0.1f;
        offset = Random.Range(0, 1);

    }
	
	// Update is called once per frame
	void Update () {
        max = sound.GetComponent<spectrum>().sample_max;

        
        Vector3 new_position;
        //Vector3 new_position = new Vector3(position.x, position.y, position.z - (max * speed));
        //just speed instead
        if ( offset ==  0)
        {
            new_position = new Vector3(position.x, position.y + (max * speed), position.z);
        } else {
            new_position = new Vector3(position.x, position.y + (max * speed) + 0.01f, position.z);
        }
            



        //print(max * speed);
        this.transform.position = new_position;
        position = new_position;
        

    }
}
