using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager SoundManager;

    public List<AudioClip> BGM_audioClips = new List<AudioClip>();
    public List<AudioClip> Effect_audioClips = new List<AudioClip>();
    public AudioSource BGM_AudioSource;
    public AudioSource Effect_AudioSource;


    void Start()
    {
        SoundManager = this;

        BGM_AudioSource.clip = BGM_audioClips[0];
        BGM_AudioSource.Play();

        Effect_AudioSource.clip = Effect_audioClips[0];
        Effect_AudioSource.Play();
    }

    float Timer = 0;
    private void Update()
    {
        if (!BGM_AudioSource.isPlaying)
        {
            Timer += Time.deltaTime;
            if (Timer > 40f)
                Playing();
        }
        else
        {
            Timer = 0;
        }
    }


    public void Open_Title()
    {
        BGM_AudioSource.clip = BGM_audioClips[0];
        BGM_AudioSource.Play();

        Effect_AudioSource.clip = Effect_audioClips[0];
        Effect_AudioSource.Play();
    }

    public void Set_Starting()
    {
        BGM_AudioSource.clip = BGM_audioClips[1];
        BGM_AudioSource.Play();

        Effect_AudioSource.Stop();
    }

    public void Playing()
    {
        BGM_AudioSource.clip = BGM_audioClips[2];
        BGM_AudioSource.Play();

        Effect_AudioSource.Stop();
    }

    public void Player_Dead()
    {
        BGM_AudioSource.clip = BGM_audioClips[3];
        BGM_AudioSource.Play();

        Effect_AudioSource.Stop();
    }

    public void Player_Eating()
    {
        Effect_AudioSource.clip = Effect_audioClips[1];
        Effect_AudioSource.Play();
    }

    public void Open_Bag()
    {
        Effect_AudioSource.clip = Effect_audioClips[2];
        Effect_AudioSource.Play();
    }

    public void Close_Bag()
    {
        Effect_AudioSource.clip = Effect_audioClips[3];
        Effect_AudioSource.Play();
    }

    public void Player_Drinking()
    {
        Effect_AudioSource.clip = Effect_audioClips[4];
        Effect_AudioSource.Play();
    }

    public void System_Open()
    {
        Effect_AudioSource.clip = Effect_audioClips[5];
        Effect_AudioSource.Play();
    }
}
