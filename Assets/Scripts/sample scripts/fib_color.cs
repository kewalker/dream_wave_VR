using UnityEngine;
using System.Collections;

public class fib_color : MonoBehaviour {
    float offset;
    Color [] color = new Color [5];

    public Color start = new Color(1, 0.35f, 0.01f);

    int index = 0;

    int n = 5;
    //private Gradient gradient;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        offset = Random.Range(0f, 20f);


        if (Time.frameCount % 64 == 0)
        {
            for (int i = 0; i < n; i++)
            {
                color[i] = new Color((start.r + (offset + (0.618033988749895f * i))) % 1, (start.g + (offset + (0.618033988749895f * i))) % 1, (start.b + (offset + (0.618033988749895f * i))) % 1);
                print(color[i]);
            }
            this.GetComponent<Renderer>().material.color = (color[index % color.Length]);
            index++;
        }
    }
}
