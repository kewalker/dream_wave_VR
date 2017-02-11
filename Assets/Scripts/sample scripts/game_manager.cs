using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class game_manager : MonoBehaviour
{

    public static game_manager instance = null;

    public GameObject dream_wave_vr_text;
    public GameObject select_a_session;
    public GameObject random_relax;
    public GameObject options;

    public AudioSource[] all_audio_sources;
    List<AudioSource> paused_audio;

    public GameObject menu;

    public Object temp_text;
    public Object temp_text1;
    public Object temp_text2;

    public Text message;

    public string state;

    public GameObject test;
    
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
    }

    public void Setup()
    {
        //bypass menu
        state = "started";
        start_session();

        //uncomment for menu
        //temp_text = Instantiate(dream_wave_vr_text, new Vector3(0, 0, 10), Quaternion.identity);
        paused_audio = new List<AudioSource>();
    }

   

    public void update_message ()
    {
        print("Updating State:");
        print(state);

        if (state == "menu")
        {
            Destroy(temp_text);
            temp_text = Instantiate(select_a_session, new Vector3 (0, 3, 10), Quaternion.identity);
            temp_text1 = Instantiate(random_relax, new Vector3(0, 0, 10), Quaternion.identity);
            temp_text2 = Instantiate(options, new Vector3(0, -3, 10), Quaternion.identity);
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
        
    }

    void start_session()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        //transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
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

    void Update()
    {

    }
}