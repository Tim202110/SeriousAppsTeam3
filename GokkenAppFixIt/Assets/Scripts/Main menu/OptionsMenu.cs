using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider HoofdVolumeSlider;
    public Slider StemVolumeSlider;
    public Slider MuziekVolumeSlider;
    public Slider EffectenVolumeSlider;

    public const string MIXER_HOOFD = "HoofdVolume";
    public const string MIXER_STEM = "StemVolume";
    public const string MIXER_MUZIEK = "MuziekVolume";
    public const string MIXER_EFFECTEN = "EffectenVolume";
    void Awake()
    {
        HoofdVolumeSlider.onValueChanged.AddListener(setHoofdVolume);
        StemVolumeSlider.onValueChanged.AddListener(setStemVolume);
        MuziekVolumeSlider.onValueChanged.AddListener(setMuziekVolume);
        EffectenVolumeSlider.onValueChanged.AddListener(setEffectenVolume);
    }

    void Start()
    {
        HoofdVolumeSlider.value = PlayerPrefs.GetFloat(AudioManager.HOOFDVOLUME_KEY, 1f);
        StemVolumeSlider.value = PlayerPrefs.GetFloat(AudioManager.STEMVOLUME_KEY, 1f);
        MuziekVolumeSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        EffectenVolumeSlider.value = PlayerPrefs.GetFloat(AudioManager.EFFECTENVOLUME_KEY, 1f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.HOOFDVOLUME_KEY, HoofdVolumeSlider.value);
        PlayerPrefs.SetFloat(AudioManager.STEMVOLUME_KEY, StemVolumeSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, MuziekVolumeSlider.value);
        PlayerPrefs.SetFloat(AudioManager.EFFECTENVOLUME_KEY, EffectenVolumeSlider.value);
    }

    void setHoofdVolume(float value)
    {
        Mixer.SetFloat(MIXER_HOOFD, Mathf.Log10(value) * 20);
    }

    void setStemVolume(float value)
    {
        Mixer.SetFloat(MIXER_STEM, Mathf.Log10(value) * 20);
    }

    void setMuziekVolume(float value)
    {
        Mixer.SetFloat(MIXER_MUZIEK, Mathf.Log10(value) * 20);
    }

    void setEffectenVolume(float value)
    {
        Mixer.SetFloat(MIXER_EFFECTEN, Mathf.Log10(value) * 20);
    }
}
