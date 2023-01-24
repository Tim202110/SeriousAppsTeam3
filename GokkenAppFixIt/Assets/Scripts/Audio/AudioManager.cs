using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource Maudio;
    [SerializeField] List<AudioClip> audioclip = new List<AudioClip>();

    public const string HOOFDVOLUME_KEY = "HoofdVolume";
    public const string STEMVOLUME_KEY = "EffectenVolume";
    public const string MUSIC_KEY = "MuziekVolume";
    public const string EFFECTENVOLUME_KEY = "EffectenVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    public void Audio()
    {
        AudioClip clip = audioclip[Random.Range(0, audioclip.Count)];

        Maudio.PlayOneShot(clip);
    }

    void LoadVolume() //Volume saved in OptionsMenu.cs
    {
        float HoofdVolume = PlayerPrefs.GetFloat(HOOFDVOLUME_KEY, 1f);
        float StemVolume = PlayerPrefs.GetFloat(STEMVOLUME_KEY, 1f);
        float MuziekVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float EffectenVolume = PlayerPrefs.GetFloat(EFFECTENVOLUME_KEY, 1f);

        mixer.SetFloat(OptionsMenu.MIXER_HOOFD, Mathf.Log10(HoofdVolume) * 20);
        mixer.SetFloat(OptionsMenu.MIXER_STEM, Mathf.Log10(StemVolume) * 20);
        mixer.SetFloat(OptionsMenu.MIXER_MUZIEK, Mathf.Log10(MuziekVolume) * 20);
        mixer.SetFloat(OptionsMenu.MIXER_EFFECTEN, Mathf.Log10(EffectenVolume) * 20);
    }
}
