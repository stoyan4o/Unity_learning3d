//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    // Singleton

    public static AudioMgr Instance;

    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource _effectSource;

    [SerializeField] Sound[] sounds;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        //c//_audioSource = GetComponent<AudioSource>();
        for(int i=0;i<sounds.Length;i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].Name);
            _go.transform.SetParent(this.transform);
            AudioSource source = _go.AddComponent<AudioSource>();
            sounds[i].SetSource(source);
            Debug.Log("creating sound " + sounds[i].Name);
        }

       PlaySound("invite");
         
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void PlaySound(string clipName)
    {
        foreach (Sound s in sounds)
        {
            if (s.Name.CompareTo(clipName) == 0)
            {
                _effectSource.volume = s.volume;
                _effectSource.PlayOneShot(s.Clip);
                Debug.Log("playing - " + clipName);
                break;
            }
        }
        Debug.Log("not found - " + clipName);
    }

    internal void PlayBallHitsPlayer(Vector3 position)
    {
        //_audioSource.clip = bounceBall;
         //   _audioSource.Play();
        // AudioSource.PlayClipAtPoint(bounceBall, position);
    }

    internal void PlayBallHitsWall(Vector3 position)
    {
        //_audioSource.clip = bounceWall;
        // _audioSource.Play();
        // AudioSource.PlayClipAtPoint(bounceWall, position);
    }

     
}

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;          // the sound file to play

    private AudioSource _source;
    [Range(0f,1f)]
    public float volume;
    [Range(0.5f, 0.5f)]
    public float pitch;

    [Range(0f,0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public void SetSource(AudioSource aSource)
    {
        _source = aSource;
        _source.clip = Clip;
    }

    public void Play()
    {
        _source.volume = volume * (1+ Random.Range(-randomVolume / 2f, randomVolume/2f));
        _source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        _source.Play();
    }


     
     
}
 