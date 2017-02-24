using UnityEngine;
using System.Collections;

public class sphere_spectrum : MonoBehaviour {

    public int intensity;
    public int frame_count_delay;

    public Vector3 original_scale;

    public Camera sound;

    public GameObject stretch;

    // Use this for initialization
    void Start () {

        intensity = 5;
        frame_count_delay = 4;
        original_scale = gameObject.transform.localScale;
        sound = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        //float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
        float max;
        if (Time.frameCount % frame_count_delay == 0)
        {
            /*max = spectrum[0];
            for ( int i = 0; i < spectrum.Length; i++ )
            {
                if (spectrum[i] > max)
                {
                    max = spectrum[i];
                }
            }*/
            max = sound.GetComponent<spectrum>().sample_max;


            Vector3 previousScale = stretch.transform.localScale;
            previousScale.y = original_scale.x + (max * intensity);
            previousScale.x = original_scale.y + (max * intensity);
            previousScale.z = original_scale.z + (max * intensity);

            stretch.transform.localScale = previousScale;

                
            
            //Debug.Log(previousScale.y);
            //cubes[i].transform.localScale = previousScale;
            //cubes[i].transform.Rotate(0, 0.1f, 0);
        }


    }
}
