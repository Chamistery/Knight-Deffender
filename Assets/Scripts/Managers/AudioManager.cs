using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSource;

    [SerializeField] private AudioSource music1Source;

    [SerializeField] private AudioSource music2Source;
   // public float Soundie { get; private set; }
    public float soundVolume {
        get { return AudioListener.volume; } 
        set { AudioListener.volume = value; } }
    public void PlayIntroMusic(string introBGMusic) 
    {
        PlayMusic(Resources.Load(introBGMusic) as AudioClip); 
    }
    private void PlayMusic(AudioClip clip) 
    {
        if (Pause_Menu.MSelector == 2 && Pause_Menu.RePlay)
        { music2Source.UnPause(); }
        else if(Pause_Menu.MSelector == 2)
        {
            music2Source.clip = clip; music2Source.Play();
        }
        else { music1Source.clip = clip; music1Source.Play(); }
    }
    public void StopMusic()
    {
        music1Source.Pause();
        music2Source.Pause();
    }
    public bool soundMute{ 
        get { return AudioListener.pause; } 
        set { AudioListener.pause = value; } }
    public void PlaySound(AudioClip clip) { soundSource.PlayOneShot(clip); }
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    // Место для элементов управления громкостью (листинг 11.4)

    public void Startup(NetworkService service)
    {
        
        Debug.Log("Audio manager starting...");
        _network = service;
        // Инициализация источников музыки (11.10) status = ManagerStatus.Started;
        soundVolume = SettingPopup.SoundVolume;

        status = ManagerStatus.Started;
    }
    //private void Update()
    //{
    //    if (Pause_Menu.GameIsPaused)
    //        UpdateData(SettingPopup.SoundVolume);
    //}
    private void Update()
    {
        if (Pause_Menu.GameIsPaused)
        {
            Managers.Data.SaveGameState();
        }
    }
    public void UpdateData(float result)
    {
        SettingPopup.SoundVolume = result;
        soundVolume = SettingPopup.SoundVolume;
        //  Debug.Log(soundVolume);
    }
}
