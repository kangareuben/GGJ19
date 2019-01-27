using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    [SerializeField]
    private AudioSource[] _audioSources;

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
        PlaySound(0);
    }

    public void PlaySound(int index)
    {
        if(!_audioSources[index].isPlaying)
        {
            _audioSources[index].Play();
        }
    }

    public void StopSound(int index)
    {
        _audioSources[index].Stop();
    }
}
