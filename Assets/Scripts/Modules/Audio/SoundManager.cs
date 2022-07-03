using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public const int MaxSFXPlayCount = 5;

    private float bgmVolume;
    public float BGMVolume { 
        get { return bgmVolume; }
    }
    private float sfxVolume;
    public float SFXVolume {
        get { return sfxVolume; }
    }

    private AudioSource bgmAudioPlayer;

    private Dictionary<string, SoundPool> sfxPlayerDic = new Dictionary<string, SoundPool>();
    public GameObject sfxPlayerPrefab;

    protected override void Awake()
    {
        bgmAudioPlayer = GetComponent<AudioSource>();
        base.Awake();

        bgmVolume = PlayerPrefs.GetFloat("BGM", 0.5f);
        sfxVolume = PlayerPrefs.GetFloat("SFX", 0.5f);

        bgmAudioPlayer.volume = bgmVolume;

    }

    public void ChangeBGMVolume(float bgm)
    {
        bgmVolume = bgm;
        bgmAudioPlayer.volume = bgmVolume;
        PlayerPrefs.SetFloat("BGM", bgmVolume);
    }

    public void ChangeSFXVolume(float sfx)
    {
        sfxVolume = sfx;

        var keyList = sfxPlayerDic.Keys.ToList();

        for (var i = 0; i < keyList.Count; ++i)
        {
            sfxPlayerDic[keyList[i]].ChangeVolume(sfx);
        }

        PlayerPrefs.SetFloat("SFX", sfxVolume);
    }

    public void PlayBGM(AudioClip bgm)
    {
        bgmAudioPlayer.Stop();
        bgmAudioPlayer.clip = bgm;
        bgmAudioPlayer.Play();
    }

    public void PauseBGM()
    {
        bgmAudioPlayer.Pause();
    }

    public void UnPauseBGM()
    {
        bgmAudioPlayer.UnPause();
    }

    public void StopBGM()
    {
        bgmAudioPlayer.Stop();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        SoundPool soundPool = null;

        if (!sfxPlayerDic.ContainsKey(sfxClip.name))
        {
            //Group 积己
            var groupGo = new GameObject(sfxClip.name);
            groupGo.transform.SetParent(transform);

            List<SoundPoolPlayer> sfxPlayers = new List<SoundPoolPlayer>();
            //SFX 积己 饶 殿废
            for (var i = 0; i < MaxSFXPlayCount; ++i)
            {
                var sfxGo = Instantiate(sfxPlayerPrefab, groupGo.transform);
                var sfxPlayer = sfxGo.GetComponent<SoundPoolPlayer>();
                sfxPlayer.ChangeVolume(sfxVolume);
                sfxPlayers.Add(sfxPlayer);
            }

            sfxPlayerDic.Add(sfxClip.name, new SoundPool(sfxClip, sfxPlayers));
        }

        soundPool = sfxPlayerDic[sfxClip.name];
        soundPool.PlaySFX();
    }

}
