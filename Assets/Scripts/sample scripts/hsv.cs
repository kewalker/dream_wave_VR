using UnityEngine;
using System.Collections;
//using System;

public class hsv : MonoBehaviour {
    public float interval; //= Mathf.PI / 48;
    public Color start;
    public Color next;

    public Color [] colors;
    int num_colors;

	// Use this for initialization
	void Start () {

        //Get a random interval
        interval = Random.Range(0f, 0.25f);

        //uncomment to pick ur fave start color
        //start = this.gameObject.GetComponent<Renderer>().material.color;

        //else get a random start color
        start = new Color(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f));

        next = start;

        //number of colors we want
        num_colors = 10;

        colors = new Color[num_colors];

        float h;
        float s;
        float v;

        //get a color, convert it to hsv. increment hue. add it to the array.
        for ( int i = 0; i < num_colors; i++ )
        {
            colors[i] = next;
            Color.RGBToHSV(next, out h, out s, out v);
            h += interval;
            //print("h: " + h);
            next = Color.HSVToRGB(h, s, v);
        }
    }
	
	// Update is called once per frame
    //same code as above but done each frame
	void Update () {
        /*float h;
        float s;
        float v;
        Color.RGBToHSV(next, out h, out s, out v);

        print(h);
        print(s);
        print(v);

        h += interval;
        print("h: " + h);

        next = Color.HSVToRGB(h, s, v);
        //start = next;
        this.GetComponent<Renderer>().material.color = next;*/
	}
}
