using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class game_manager : MonoBehaviour
{

    public static game_manager instance = null;

    //menu prefabs
    public GameObject dream_wave_vr_text;
    public GameObject select_a_session;
    public GameObject random_relax;
    public GameObject options;

    //random event instantiation
    public GameObject event_object;
    public Object new_event_object;

    //audio prefabs
    public AudioSource[] all_audio_sources;
    List<AudioSource> paused_audio;

    //color palette
    public Color[] colors;
    int num_colors;

    public GameObject menu;

    public Object temp_text;
    public Object temp_text1;
    public Object temp_text2;

    public Text message;

    public string state;
    
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        // Setup();
        colors = new Color[10];
    }

    void Start ()
    {
        Setup();
    }

    public void Setup()
    {
        //bypass menu
        //state = "started";
        //start_session();

        //uncomment for menu
        temp_text = Instantiate(dream_wave_vr_text, new Vector3(0, 0, 15), Quaternion.identity);
        transform.GetChild(8).gameObject.SetActive(true);
        paused_audio = new List<AudioSource>();
    }

   
    //mostly for the menu
    public void update_message ()
    {
        print("Updating State:");
        print(state);

        if (state == "menu")
        {
            Destroy(temp_text);
            temp_text = Instantiate(select_a_session, new Vector3 (0, 3, 15), Quaternion.identity);
            temp_text1 = Instantiate(random_relax, new Vector3(0, 0, 15), Quaternion.identity);
            temp_text2 = Instantiate(options, new Vector3(0, -3, 15), Quaternion.identity);
        }

        if (state == "select_a_session")
        {
            Destroy(temp_text);
            Destroy(temp_text1);
            Destroy(temp_text2);

            //temporary
            state = "started";
            start_session();
        }

        if (state == "random_relax")
        {
            Destroy(temp_text);
            Destroy(temp_text1);
            Destroy(temp_text2);
            //temporary
            state = "started";
            start_session();
        }

        if (state == "options")
        {
            Destroy(temp_text);
            Destroy(temp_text1);
            Destroy(temp_text2);
            //temporary
            state = "started";
            start_session();
        }

        if (state == "pause")
        {
            print("pause from the game_manager");
            all_audio_sources = GameObject.FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in all_audio_sources)
            {
                if (audio.isPlaying)
                {
                    audio.Pause();
                    paused_audio.Add(audio);
                }
            }

        }

        if (state == "resume")
        {
            foreach (AudioSource audio in paused_audio)
            {
                audio.UnPause();
            }
            paused_audio.Clear();
            state = "started";
        }

        if (state == "started")
        {
            start_session();
        }
        
    }


    //turn on the main components of the game
    void start_session()
    {
        //sound_1_ambient
        //transform.GetChild(0).gameObject.SetActive(true);
        //sound_2
        //transform.GetChild(1).gameObject.SetActive(true);
        
        //sound_3_drums
        transform.GetChild(2).gameObject.SetActive(true);
        //master_cube -> already active
        //transform.GetChild(3).gameObject.SetActive(true);
        //particle system
        transform.GetChild(4).gameObject.SetActive(true);
        //object_instantiator
        //transform.GetChild(5).gameObject.SetActive(true);
        
        //piano_track
        transform.GetChild(6).gameObject.SetActive(true);
        //ambient_guitar_track
        transform.GetChild(7).gameObject.SetActive(true);

        //turn off intro music
        //transform.GetChild(8).gameObject.SetActive(false);
    }

    public void set_state (string new_state)
    {
        state = new_state;
        update_message();
    }

    public string get_state ()
    {
        return state;
    }

    public void instantiate_event ()
    {
        if (new_event_object != null)
        {
            //Destroy(new_event_object);
        }

        new_event_object = Instantiate (event_object, new Vector3 (Random.Range(-5, 5), Random.Range(-3, 3), 5), Quaternion.identity);
    }

    public void set_palette ( Color [] temp)
    {
        colors = temp;
    }

    public Color [] get_palette ()
    {
        return colors;
    }


}