using UnityEngine;
using System.Collections;

public class emission_oscillate : MonoBehaviour {

    Renderer[] temp;

    int rotate_speed;

    // Use this for initialization
    void Start()
    {
        temp = gameObject.GetComponentsInChildren<Renderer>(); //.material.color;
        rotate_speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Transform child in transform)
        {
            print(child);
            child.GetComponent<Renderer>().material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
        }
        Destroy(this);*/

        foreach (Renderer rend in temp)
        {
            //weird trippy effect if don't delete script
            //print(rend);

            //if (rend.gameObject.GetInstanceID() != GetInstanceID()) { }

            //skip the first one; i.e. the parent
            //if (gameObject.transform.parent == null )
            if (rend.transform == this.transform) { }

            else {
                //if (rend != this.)
                //{
                //rend.material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
                //Renderer renderer = GetComponent<Renderer>();
                Material mat = rend.material;

                float emission = Mathf.PingPong(Time.time, 1.0f);
                Color baseColor = Color.yellow; //Replace this with whatever you want for your base color at emission level '1'

                Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

                mat.SetColor("_EmissionColor", finalColor);

                //rend.gameObject.transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), rotate_speed * Time.deltaTime);
                //print(rend.gameObject.transform.position);
                //rend.transform.position 
                //rend.transform.RotateAround(transform.parent.transform.position, new Vector3(0, 1, 0), rotate_speed * Time.deltaTime);
                rend.gameObject.transform.RotateAround(rend.transform.parent.position, new Vector3(0, 1, 0), rotate_speed * Time.deltaTime);
            }
        }
    }
}
