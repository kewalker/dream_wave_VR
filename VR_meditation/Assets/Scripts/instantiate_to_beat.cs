using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class instantiate_to_beat : MonoBehaviour
{
    public float bpm = 60.0F;

    //event segments occur in intevals of 4
    public int numBeatsPerEventSegment = 4;
    
    private double nextEventTime;

    private bool running;

    void Awake()
    {
        nextEventTime = AudioSettings.dspTime + 3;
        running = true;
    }

    void Update()
    {
        if (!running)
            return;


        double time = AudioSettings.dspTime;

        if (time + 1.0F > nextEventTime)
        {
            //instantiate event
            game_manager.instance.instantiate_event();
            nextEventTime += 60.0F / bpm * numBeatsPerEventSegment;
        }



    }
}