using UnityEngine;
using System.Collections;

public class spectrum : MonoBehaviour {

    public GameObject prefab;
    public GameObject master_cube;

    public AudioSource the_clip;

    public int numberOfObjects = 50;
    public float radius = 5f;
    public GameObject[] cubes;
    public int intensity;
    public int frame_count_delay;
    public bool started;

    public Light[] lt;

    public ParticleSystem ps;
    public Color psColor;

    public float max;
    public float sample_max;

    // Use this for initialization
    void Start() {

        //started = false;
        //print(GameObject.Find("sound_controller ").GetComponentsInChildren<AudioSource>());

        //the_clip = GameObject.Find("sound_controller ").GetComponentsInChildren<AudioSource>();

        intensity = 150;
        frame_count_delay = 4;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Object temp = Instantiate(prefab, pos, Quaternion.identity);
        }

        cubes = GameObject.FindGameObjectsWithTag("cubes");

        

        //for (int i = 0; i < numberOfObjects; i++)
        //{
        //cubes[i].transform.localScale = new Vector3 ()
        //cubes[i].SetActive(false);
        started = true;
        //}

    }

    // Update is called once per frame
    void Update() {

        if (started == true)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                //print(i);
                cubes[i].GetComponent<Renderer>().material.color = this.GetComponent<hsv>().colors[(i % 10)];
            }
            started = false;
        }

        float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);

        float[] clip_spectrum = the_clip.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

        //float [] spectrum_2 = AudioSource.Get


        sample_max = 0;
        float temp;
        //new spectrum lookup
        float[] samples = AudioListener.GetOutputData(1024, 0);
        foreach (float sample in samples)
        {
            //print(sample);
            temp = (sample + 1f) / 2f;
            if (sample > sample_max)
            {
                sample_max = sample;
            }
        }
        //print("sample max: " + sample_max);
        //Debug.Log(spectrum.Length);
        
        //get new random color every 64 frames:
        if (Time.frameCount % 64 == 0)
        {
            //get two random colors
            Color random_color = new Color((Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)));
            Color other_color = new Color((Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)));
            //interpolate between them
            psColor = Color.Lerp(random_color, other_color, Mathf.PingPong(Time.time, 1));
            //set the particle system's color
            ps.startColor = psColor;

        }

        //frame count delay 
        if (Time.frameCount % frame_count_delay == 0)
        {
            //set placeholder for max
            max = spectrum[0];
            for (int i = 0; i < spectrum.Length; i++)
            {
                if (spectrum[i] > max)
                {
                    max = spectrum[i];
                }
            }

            //print("max: " + max);

            //for each cube, stretch it
            for (int i = 0; i < numberOfObjects; i++)
            {
                Vector3 previousScale = cubes[i].transform.localScale;
                previousScale.y = (spectrum[i] * intensity);
                //Debug.Log(previousScale.y);

                cubes[i].transform.localScale = previousScale;
                //and rotate 'em
                cubes[i].transform.Rotate(0, 0.1f, 0);
            }
        }


    }
}