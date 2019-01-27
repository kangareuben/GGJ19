using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    [SerializeField]
    private AudioSource[] _audioSources;

    private float musicVolume;
    private bool _soundOn = true;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicVolume = _audioSources[0].volume;
        PlaySound(0);
    }

    public void PlaySound(int index)
    {
        if(!_audioSources[index].isPlaying && _soundOn)
        {
            _audioSources[index].Play();
        }
    }

    public void StopSound(int index)
    {
        _audioSources[index].Stop();
    }

    public void SetVolume(int index, float volume)
    {
        _audioSources[index].volume = volume;
    }

    public void ToggleMute()
    {
        _soundOn = !_soundOn;

        if(!_soundOn)
        {
            SetVolume(0, 0f);
        }
        else
        {
            SetVolume(0, musicVolume);
        }
    }
}
