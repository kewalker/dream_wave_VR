using UnityEngine;
using System.Collections;

public class color_assign : MonoBehaviour {

    Renderer[] temp;

	// Use this for initialization
    void Awake()
    {
        //get all the children's renderers in an array
        temp = gameObject.GetComponentsInChildren<Renderer>();
        //foreach (Renderer rend in temp)
        //{
          //  gameObject.GetComponent<Renderer>().enabled = false;
        //}

        StartCoroutine(Blink(0.05f));
    }

    void Start () {

        

        //get all the children's renderers in an array
        //temp = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in temp)
        {

            //skip the first one; i.e. the parent
            //if (gameObject.transform.parent == null )
            if (rend.transform == this.transform)
            {
                //comment out below to omit parent
                rend.material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
            }
            else {
                //we found a child, pick the color
                rend.material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
            }
        }

        //weird trippy effect if don't delete script - i.e. comment out below
        //Destroy(this);
    }
//}


	
	// Update is called once per frame
	/*void Update () {
	    
        foreach (Renderer rend in temp)
        {
            
            //skip the first one; i.e. the parent
            //if (gameObject.transform.parent == null )
            if (rend.transform == this.transform) {
                //comment out below to omit parent
                rend.material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
            }
            else {
                //we found a child, pick the color
                rend.material.color = FindObjectOfType<Camera>().GetComponent<hsv>().colors[Random.Range(0, 10)];
            }
        }
        //weird trippy effect if don't delete script - i.e. comment out below
        //Destroy(this);
	}*/

    IEnumerator Blink (float time_off)
    {
        foreach (Renderer rend in temp) {
            rend.enabled = false;
        }

        yield return new WaitForSeconds(time_off);

        foreach (Renderer rend in temp)
        {
            rend.enabled = true;
        }

        //gameObject.GetComponent<Renderer>().enabled = true;
        Destroy(this);
    }


}

