using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class fade_in_mixer : MonoBehaviour {

    public AudioMixer mixer_audio;

    public float volume;

	// Use this for initialization
	void Start () {
        //audio = AudioMixerSnapshot //GameObject.Find("master");
        volume = -20;
        mixer_audio.SetFloat("MyExposedParam", volume);

    }
	
	// Update is called once per frame
	void Update () {
        volume += 0.5f * Time.deltaTime;
        mixer_audio.SetFloat("MyExposedParam", volume);
        
        if (volume > 0.00f)
        {
            volume = 0;
            mixer_audio.SetFloat("MyExposedParam", volume);
            Destroy(this);
        }
	}
}
