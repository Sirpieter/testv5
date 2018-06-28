using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Transitionaudio : MonoBehaviour {

    public AudioMixer mixer;
    private AudioMixerSnapshot normalSnapshot;
    private AudioMixerSnapshot lowVolumeSnapshot;

	// Use this for initialization
	void Start () 
    {
        normalSnapshot = mixer.FindSnapshot("Normal");
        lowVolumeSnapshot = mixer.FindSnapshot("LowVolume");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mixer.ClearFloat("MasterVolume");
            lowVolumeSnapshot.TransitionTo(0.5f);
        }

        if(Input.GetMouseButton(0))
        {
            float currentVolume;
            mixer.GetFloat("MasterVolume", out currentVolume);

            mixer.SetFloat("MasterVolume", currentVolume + .1f);
        }
	}
}
