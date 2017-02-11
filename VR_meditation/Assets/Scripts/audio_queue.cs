using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class audio_queue : MonoBehaviour
{
    public float bpm = 60.0F;

    //audio segments occur in intervals of 32
    public int numBeatsPerSegment = 32;

    //event segments occur in intevals of 4
    public int numBeatsPerEventSegment = 4;

    public AudioClip[] clips = new AudioClip[2];

    private double nextAudioTime;
    private double nextEventTime;
    public int flip = 0;
    public AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;

    void Awake()
    {
        //int i = 0;
        nextEventTime = nextAudioTime = AudioSettings.dspTime + 2.0F;
        audioSources = gameObject.GetComponents<AudioSource>();
        //while (i < 2)
        //{
        //GameObject child = new GameObject("Player");
        //child.transform.parent = gameObject.transform;
        //audioSources[i] = child.AddComponent<AudioSource>();
        //audioSources[i] = this.gameObject.get

        //i++;
        //}

        
        running = true;
    }
    void Update()
    {
        if (!running)
            return;

        double time = AudioSettings.dspTime;
        if (time + 1.0F > nextAudioTime)
        {
            audioSources[flip].clip = clips[flip];

            //flip the clip to process with audio_processing script
            gameObject.GetComponent<audio_processing>().the_clip = audioSources[flip];
            audioSources[flip].PlayScheduled(nextAudioTime);
            Debug.Log("Scheduled source " + flip + " to start at time " + nextAudioTime);

            //schedules next audio time
            nextAudioTime += 60.0F / bpm * numBeatsPerSegment;
            flip = 1 - flip;
        }
        
        //moved to new script
        /*if (time + 1.0F > nextEventTime)
        {
            //instantiate event
            game_manager.instance.instantiate_event();
            nextEventTime += 60.0F / bpm * numBeatsPerEventSegment;
        }*/



    }
}