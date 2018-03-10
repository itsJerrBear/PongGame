using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //need to store different sound effects... will only ever have 1 sound manager

    public static SoundManager Instance = null;

    //set up names for sound effects
    public AudioClip GoalBloop;
    public AudioClip LossBuzz;
    public AudioClip HitPaddleBloop;
    public AudioClip WinSound;
    public AudioClip WallBloop;

    private AudioSource soundEffectAudio;


    // Use this for initialization
    void Start () {

        //only want 1 sound manager
        if (Instance == null)
        {
            Instance = this;
        }

        //remove all other sound managers
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach(AudioSource source in sources)
        {
            if (source.clip == null)
            {
                soundEffectAudio = source;
            }
        }

	}
	
	//function for other game objects to call to make sounds
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
