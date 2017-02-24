using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size_oscillate : MonoBehaviour
{

    public Renderer[] temp;
    Vector3 local_scale;
    int rotate_speed;

    // Use this for initialization
    void Start()
    {
        temp = gameObject.GetComponentsInChildren<Renderer>(); //.material.color;
        local_scale = gameObject.transform.localScale;
        rotate_speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Renderer rend in temp)
        {
            /*if (rend.transform == this.transform) {
                float emission = 1 - Mathf.PingPong(Time.time, 0.5f);

                Vector3 scale_change = local_scale * Mathf.LinearToGammaSpace(emission);
                gameObject.transform.localScale = scale_change;
            }
            else*/

            if (rend.transform == this.transform.GetChild(0).transform)
            {
                float emission = 2.0f - Mathf.PingPong(Time.time, 0.5f);

                Vector3 scale_change = local_scale * Mathf.LinearToGammaSpace(emission);
                rend.transform.localScale = scale_change;
            }
        }
    }
}