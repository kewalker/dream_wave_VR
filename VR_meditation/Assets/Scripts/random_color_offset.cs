using UnityEngine;
using System.Collections;

public class random_color_offset : MonoBehaviour {

    public GameObject thing;

    public Color start_color;

    public float offset;


	// Use this for initialization
	void Start () {
        start_color = thing.GetComponent<Renderer>().material.color;
        offset = 0.25f;
    }
	
	// Update is called once per frame
	void Update () {
        float value = (start_color.r + start_color.g + start_color.b) / 3;
        float newValue = value + 2 * Random.Range(0f, 0.5f) * offset - offset;

        float value_ratio = newValue / value;

        //print(value_ratio);

        Color new_color = new Color(start_color.r * value_ratio, start_color.g * value_ratio, start_color.b * value_ratio);

        thing.GetComponent<Renderer>().material.color = new_color;

        print(new_color);

        //start_color = new_color;
    }
}
