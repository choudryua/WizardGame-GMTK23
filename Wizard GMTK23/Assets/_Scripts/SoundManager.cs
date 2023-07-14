using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource _musicSource, _effectsSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        try
        {
            _effectsSource.PlayOneShot(clip);
        }
        catch (System.Exception e)
        {
            print(e.ToString());
        }
    }

    public void StopSound(AudioClip clip)
    {
        
    }
}
