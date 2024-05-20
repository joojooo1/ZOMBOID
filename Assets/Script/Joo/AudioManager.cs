using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager SoundManager;

    public List<AudioClip> BGM_audioClips = new List<AudioClip>();
    public List<AudioClip> SFX_audioClips = new List<AudioClip>();
    public AudioSource BGM_AudioSource;
    public AudioSource Effect_AudioSource;

    public UnityEngine.Audio.AudioMixer masterMixer;
    public UnityEngine.UI.Slider Master_Slider;
    public UnityEngine.UI.Slider BGM_Slider;
    public UnityEngine.UI.Slider SFX_Slider;

    void Start()
    {
        SoundManager = this;

        BGM_AudioSource.clip = BGM_audioClips[0];
        BGM_AudioSource.Play();

        Effect_AudioSource.clip = SFX_audioClips[0];
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

    public void AuidoControl()
    {
        float sound = Master_Slider.value;

        if (sound <= -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    }

    public void AuidoControl_BGM()
    {
        float sound = BGM_Slider.value;

        if (sound <= -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void AuidoControl_SFX()
    {
        float sound = SFX_Slider.value;

        if (sound <= -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }

    public void Open_Title()
    {
        BGM_AudioSource.clip = BGM_audioClips[0];
        BGM_AudioSource.Play();

        Effect_AudioSource.clip = SFX_audioClips[0];
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
        Effect_AudioSource.clip = SFX_audioClips[1];
        Effect_AudioSource.Play();
    }

    public void Open_Bag()
    {
        Effect_AudioSource.clip = SFX_audioClips[2];
        Effect_AudioSource.Play();
    }

    public void Close_Bag()
    {
        Effect_AudioSource.clip = SFX_audioClips[3];
        Effect_AudioSource.Play();
    }

    public void Player_Drinking()
    {
        Effect_AudioSource.clip = SFX_audioClips[4];
        Effect_AudioSource.Play();
    }

    public void System_Open()
    {
        Effect_AudioSource.clip = SFX_audioClips[5];
        Effect_AudioSource.Play();
    }
}
