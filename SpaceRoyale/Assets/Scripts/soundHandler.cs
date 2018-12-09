using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHandler : MonoBehaviour {



    [SerializeField]
    public List<AudioClip> soundsSer;

    public static List<AudioClip> sounds;
    public static AudioSource mainSound;

	// Use this for initialization
	void Start () {
        sounds = soundsSer;

        mainSound = new AudioSource();

 //       mainSound.loop = true;
 //       mainSound.clip = sounds[5];
 //       mainSound.Play();
        PlaySound(5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void PlaySound(int i)
    {
        AudioSource.PlayClipAtPoint(sounds[i], new Vector3(0, 0, 0));

    }
    public static void Engine()
    {
        //PlaySound(0);
    }
    public static void Crowd()
    {
        PlaySound(Random.Range(1, 3));
    }
    public static void Explode()
    {
        PlaySound(4);
    }


}
