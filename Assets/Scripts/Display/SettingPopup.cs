using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    public Slider slider;
    public static float SoundVolume = .1f;
    private void Start()
    {
        slider.value = SoundVolume;
    }
    public void OnSoundToggle() { Managers.Audio.soundMute = !Managers.Audio.soundMute; }
    public void OnSoundValue(float volume) { Managers.Audio.soundVolume = volume; SoundVolume = volume; }
}
