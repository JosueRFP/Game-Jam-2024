using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;

   public static AudioManager instance;

    private void Awake()
    {

        if (instance == null) 
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) 
        { 
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.soundClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.canLoop;
            
        }
    }

    private void Start()
    {
        Play("Musiquinha");
    }

    public void Play(string name) 
    { 
       Sound s = Array.Find(sounds,sounds => sounds.soundName == name);
       s.source.Play();
    }
}
