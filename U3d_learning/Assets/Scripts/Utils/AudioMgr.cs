using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    // Singleton
    public static AudioMgr Intance { get; private set; }

    public static Sound[] sounds;

    public static AudioSource[] _audioSource;
    
    public static AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // AudioMgr.PlaySound(SoundType.BallHitsBrick);
    }

    
    
    public static void PlaySound(SoundType stype)
    {
        switch(stype)
        {
            case SoundType.BallHitsBrick:
                AudioMgr._audioSource[0].Play();
                break;
                    
            case SoundType.BallHitsWall:
                AudioMgr._audioSource[1].Play();
                break;
        }
    }
}

[System.Serializable]
public class Sound
{
    public Sound()
    {

    }
}
public enum SoundType
{
    BallHitsBrick,
    BallHitsWall
}