using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class color_controller : MonoBehaviour {

    int color_count;
    float offset_angle_1;
    float offset_angle_2;
    float range_angle_0;
    float range_angle_1;
    float range_angle_2;
    float saturation;
    float luminance;

   // public List<HSL> colors = new List<HSL>();


	// Use this for initialization
	void Start () {

        color_count = 5;

        offset_angle_1 = Random.Range(0f, 360f);
        offset_angle_2 = Random.Range(0f, 360f);

        range_angle_0 = 15f;
        range_angle_1 = 30f;
        range_angle_2 = 45f;

        saturation = 50;
        luminance = 50;

        float reference_angle = Random.Range(0f, 360f);

        for (int i = 0; i < color_count; i++)
        {
            float random_angle = Random.Range(0f, 360f) * (range_angle_0 + range_angle_1 + range_angle_2);

            if (random_angle > range_angle_0)
            {
                if (random_angle < range_angle_0 + range_angle_1)
                {
                    random_angle += offset_angle_1;
                }
                else
                {
                    random_angle += offset_angle_2;
                }
            }

            /* HSL hslColor = new HSL(
                 ((reference_angle + random_angle) / 360.0f) % 1.0f,
                 saturation,
                 luminance);

             colors.Add(hslColor.Color);

         }

         foreach (Color c in colors)
         {
             print("Here's the color" + c);
         }*/
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
