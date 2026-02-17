using System;
using Unity.VisualScripting;
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
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    /// <summary>
    /// Play one shot sound given name
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pitchRandomization"></param>
    public void PlayOneShot(string name, float pitchRandomization = 0)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "' not found!");
            return;
        }

        if (pitchRandomization != 0) s.source.pitch = UnityEngine.Random.Range(1 - pitchRandomization, 1 + pitchRandomization); ;
        s.source.PlayOneShot(s.audioClip);
    }

    public void Play(string name, float pitchRandomization = 0)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "' not found!");
            return;
        }

        else if (s.source.isPlaying) return;

        if (pitchRandomization != 0) s.source.pitch = UnityEngine.Random.Range(1 - pitchRandomization, 1 + pitchRandomization); ;
        s.source.Play();
    }

    /// <summary>
    /// Stops specified source from playing
    /// </summary>
    /// <param name="name"> name of source </param>
    public void StopSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "' not found!");
            return;
        }

        s.source.Stop();
    }

    public void PlayLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;

        s.source.clip = s.audioClip;
        s.source.loop = true;
        s.source.Play();
    }

    public void StopLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;

        s.source.Stop();
    }
}