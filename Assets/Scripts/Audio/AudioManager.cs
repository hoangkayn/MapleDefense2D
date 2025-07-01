using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BGM,
    SFX
}

public class AudioManager : Singleton<AudioManager>
{
    [Header("Sound Data List")]
     [SerializeField] private List<SoundData> soundDataList;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] protected Dictionary<string, SoundData> soundDict = new();
      private const string BGM_KEY = "BGM_VOLUME";
    private const string SFX_KEY = "SFX_VOLUME";
    protected override void Awake()
    {
        base.Awake();

        InitSoundDict();
    }
    protected override void Start()
    {
        base.Start();
        LoadVolumeSettings();
        Play("BGM_StartGame");
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBgmSource();
        this.LoadSfxSource();
        this.LoadSoundDataList();
    }
    
    protected virtual void LoadSoundDataList()
    {
        if (soundDataList.Count > 0) return;
        SoundData[] allSoundSO = Resources.LoadAll<SoundData>("SO/Audio");
        soundDataList.AddRange(allSoundSO);
      
    }
    protected virtual void LoadBgmSource()
    {
        if (bgmSource != null) return;
        bgmSource = transform.Find("Music").GetComponent<AudioSource>();
    }
    protected virtual void LoadSfxSource()
    {
        if (sfxSource != null) return;
        sfxSource = transform.Find("SFX").GetComponent<AudioSource>();
    }
    private void InitSoundDict()
    {
        foreach (var sound in soundDataList)
        {
            if (!soundDict.ContainsKey(sound.id))
                soundDict.Add(sound.id, sound);
        }
    }
    public void Play(string id)
    {
        if (!soundDict.ContainsKey(id))
        {
            Debug.LogWarning($"Sound ID {id} not found");
            return;
        }

        SoundData sound = soundDict[id];
        AudioSource source = sound.soundType == SoundType.BGM ? bgmSource : sfxSource;

        source.clip = sound.clip;
        source.loop = sound.loop;
        source.Play();
    }
    public void PlayOneShot(string id)
    {
        if (!soundDict.ContainsKey(id)) return;
        SoundData sound = soundDict[id];
        if (sound.soundType == SoundType.SFX)
            sfxSource.PlayOneShot(sound.clip);
    }
    public void Stop(SoundType type)
    {
        if (type == SoundType.BGM) bgmSource.Stop();
        else sfxSource.Stop();
    }
    public void SetVolume(SoundType type, float volume)
    {
        volume = Mathf.Clamp01(volume);

        if (type == SoundType.BGM)
        {
            bgmSource.volume = volume;
            PlayerPrefs.SetFloat(BGM_KEY, volume);
        }
        else
        {
            sfxSource.volume = volume;
            PlayerPrefs.SetFloat(SFX_KEY, volume);
        }
          PlayerPrefs.Save();
    }
    public float GetVolume(SoundType type)
    {
        return type == SoundType.BGM ? bgmSource.volume : sfxSource.volume;
    }
    private void LoadVolumeSettings()
    {
     bgmSource.volume = PlayerPrefs.GetFloat(BGM_KEY, 1f);
        sfxSource.volume = PlayerPrefs.GetFloat(SFX_KEY, 1f); 
    }
}
