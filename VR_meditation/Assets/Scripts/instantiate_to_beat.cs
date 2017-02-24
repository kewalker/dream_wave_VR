using UnityEngine;
using System.Collections;
//using System;

[RequireComponent(typeof(AudioSource))]
public class instantiate_to_beat : MonoBehaviour
{
    public audio_queue_2 audio_queue;

    public GameObject [] to_be_created;
    public GameObject game_of_life;
    public GameOfLife3D game_of_life_script;

    public GameObject fib;

    int num;
    public int num_1;
    public int num_2;

    public int count;

    public int numBeatsPerEventSegment;
    public float bpm;
    private double nextEventTime;

    void Start()
    {
        count = 1;
        audio_queue = gameObject.GetComponent<audio_queue_2>();
        game_of_life = GameObject.FindGameObjectWithTag("game_of_life");
        game_of_life_script = game_of_life.GetComponent<GameOfLife3D>();
        //the parents
        //numBeatsPerEventSegment = audio_queue.numBeatsPerEventSegment;
        numBeatsPerEventSegment = 1;

        bpm = audio_queue.bpm;
        nextEventTime = AudioSettings.dspTime + 3;

        num = 0;
        num_1 = 0;
        num_2 = 1;

        fib.GetComponent<TextMesh>().text = ("1");
    }

    void Update ()
    {
        //if audio_queue.
        double time = AudioSettings.dspTime;

        

        if (time + 0.1F > nextEventTime)
        {
            //instantiate event
            //cycle thru 1,2,3,4
            GameObject temp = Instantiate(to_be_created[count], new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 15), Quaternion.identity);
            temp.AddComponent<shrink_and_destroy>();

            //get game_of_life to update on the beat
            game_of_life_script.UpdateGrid();

            //fib sequence
            GameObject temp_2 = Instantiate(fib, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 15), Quaternion.identity);
            temp_2.AddComponent<shrink_and_destroy>();
            //int new_text = System.Convert.ToInt32(fib.GetComponent<TextMesh>().text);
            fib.GetComponent<TextMesh>().text = System.Convert.ToString((num_1 + num_2));
            num = num_1;
            num_1 = num_2;
            num_2 = num + num_2;
            
            //reset if roll-over
            if (num_2 < 0)
            {
                num = 0;
                num_1 = 0;
                num_2 = 1;
                fib.GetComponent<TextMesh>().text = System.Convert.ToString((num_1 + num_2));
            }

            nextEventTime += 60.0F / bpm * numBeatsPerEventSegment;
            count = (count + 1) % to_be_created.Length;
        }
    }


    /*public float bpm = 60.0F;

    //event segments occur in intevals of 4
    public int numBeatsPerEventSegment;
    
    private double nextEventTime;

    private bool running;

    void Start()
    {
        nextEventTime = AudioSettings.dspTime + 3;
        running = true;

        numBeatsPerEventSegment = 4;
    }

    void Update()
    {
        if (!running)
            return;


        double time = AudioSettings.dspTime;

        if (time + 1.0F > nextEventTime)
        {
            //instantiate event
            //game_manager.instance.instantiate_event();

           // GameObject.FindGameObjectWithTag("game_of_life").GetComponent<GameOfLife3D>().UpdateGrid();

            nextEventTime += 60.0F / bpm * numBeatsPerEventSegment;
            
        }
    }*/
    }