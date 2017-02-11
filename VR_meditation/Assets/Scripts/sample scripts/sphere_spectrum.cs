using UnityEngine;
using System.Collections;

public class sphere_spectrum : MonoBehaviour {

    public int intensity;
    public int frame_count_delay;

    public GameObject stretch;

    // Use this for initialization
    void Start () {

        intensity = 50;
        frame_count_delay = 4;

    }
	
	// Update is called once per frame
	void Update () {
        float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
        float max;
        if (Time.frameCount % frame_count_delay == 0)
        {
            max = spectrum[0];
            for ( int i = 0; i < spectrum.Length; i++ )
            {
                if (spectrum[i] > max)
                {
                    max = spectrum[i];
                }
            }
            Vector3 previousScale = stretch.transform.localScale;
            previousScale.y = (max * intensity);
            previousScale.x = (max * intensity);
            previousScale.z = (max * intensity);

            stretch.transform.localScale = previousScale;

                
            
            //Debug.Log(previousScale.y);
            //cubes[i].transform.localScale = previousScale;
            //cubes[i].transform.Rotate(0, 0.1f, 0);
        }


    }
}
