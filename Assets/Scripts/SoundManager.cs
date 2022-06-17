using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance()
    {
        return instance;
    }

    [SerializeField] List<AudioSource> audioSources;

    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private List<SoundData> soundDatas;

    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    private AudioSource GetUnusedAudioSource()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return audioSources[i];
            }
        }
        return null;
    }


    public void Play(AudioClip clip)
    {
        AudioSource audioSource = GetUnusedAudioSource();
        if (audioSource == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        AudioSource audioSource = GetUnusedAudioSource();
        if (audioSource == null) return;

        foreach(var a in audioSources)
        {
            if(a.loop)
            {
                a.loop = false;
                a.Stop();
            }
        }
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //ŠÇ——pDictionary ‚©‚çA•Ê–¼‚Å’Tõ
        {
            Play(soundData.audioClip); //Œ©‚Â‚©‚Á‚½‚çAÄ¶
        }
        else
        {
            Debug.LogWarning($"‚»‚Ì•Ê–¼‚Í“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ:{name}");
        }
    }

    public void PlayLoop(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //ŠÇ——pDictionary ‚©‚çA•Ê–¼‚Å’Tõ
        {
            PlayLoop(soundData.audioClip); //Œ©‚Â‚©‚Á‚½‚çAÄ¶
        }
        else
        {
            Debug.LogWarning($"‚»‚Ì•Ê–¼‚Í“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ:{name}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
