using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class audio_queue : MonoBehaviour
{
    public float bpm = 60.0F;
    public int numBeatsPerSegment = 32;
    public AudioClip[] clips = new AudioClip[2];
    private double nextEventTime;
    public int flip = 0;
    public AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;
    void Awake()
    {
        //int i = 0;

        audioSources = gameObject.GetComponents<AudioSource>();
        //while (i < 2)
        //{
            //GameObject child = new GameObject("Player");
            //child.transform.parent = gameObject.transform;
            //audioSources[i] = child.AddComponent<AudioSource>();
            //audioSources[i] = this.gameObject.get

            //i++;
        //}
        nextEventTime = AudioSettings.dspTime + 2.0F;
        running = true;
    }
    void Update()
    {
        if (!running)
            return;

        double time = AudioSettings.dspTime;
        if (time + 1.0F > nextEventTime)
        {
            audioSources[flip].clip = clips[flip];
            gameObject.GetComponent<audio_processing>().the_clip = audioSources[flip];
            audioSources[flip].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled source " + flip + " to start at time " + nextEventTime);
            nextEventTime += 60.0F / bpm * numBeatsPerSegment;
            flip = 1 - flip;
        }
    }
}