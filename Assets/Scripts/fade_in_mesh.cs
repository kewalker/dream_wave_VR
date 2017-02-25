using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_in_mesh : MonoBehaviour {

    public Renderer rend;
    public Color color;

    void Awake ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        //rend.material.SetFloat("_Mode", 3.0f);
        // rend.material.shader = Shader.Find("Transparent/Diffuse");
        rend.material.shader = Shader.Find("Transparent/Diffuse");

        //g[i].GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
    }

	// Use this for initialization
	void Start () {
        color = rend.material.color;
        color = new Color(color.r, color.g, color.b, 0);
        rend.material.color = color;
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        color = new Color(color.r, color.g, color.b, color.a + (Time.deltaTime * Time.deltaTime));
        rend.material.color = color;
        //fully transitioned to opaque
        if (color.a > 1)
        {
            //rend.material.shader = Shader.Find("Standard");
            Destroy(this);
        }
	}
}
