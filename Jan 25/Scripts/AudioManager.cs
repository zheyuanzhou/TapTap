using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] bgm;
    public AudioSource[] sfx;

    public Text bgmValueText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBGM(0);
        bgmValueText.text = (bgm[0].volume * 10).ToString("F0");
    }

    public void PlayBGM(int musicIndex)
    {
        if (!bgm[musicIndex].isPlaying)//MARKER avoid Repeated BGM
        {
            StopMusic();

            if (musicIndex < bgm.Length)
            {
                bgm[musicIndex].Play();
            }
        }
    }

    public void PlaySFX(int soundIndex)
    {
        if (soundIndex < sfx.Length)
        {
            sfx[soundIndex].Play();
        }
    }

    public void StopMusic()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void SetBGMVolume(float _num)
    {
        bgm[0].volume += (_num / 10);
        float value = bgm[0].volume * 10;
        bgmValueText.text = value.ToString("F0");
    }
}
