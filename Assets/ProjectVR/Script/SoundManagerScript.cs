using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    [Header("Audio")]
    public AudioClip[] BgmPlaylist;
    public int MinimumTimeBeforeNextBGM;
    public int MaximumTimeBeforeNextBGM;
    public float BgmFadeInDuration;
    public AudioClip BGS;

    [Header("Components")]
    public AudioSource BgmPlayer;
    public AudioSource BgsPlayer;

    [Header("Volume")]
    public float GeneralVolume;
    public float BgmVolume;
    public float BgsVolume;

    public string BGMVolumeOptionName = "BGM Volume";
    public string BGSVolumeOptionName = "BGS Volume";
    public string GeneralVolumeOptionName = "General Volume";

    bool bWaitForBGM;
    void Start()
    {
        BgmPlayer.loop = false;
        BgsPlayer.loop = true;
        if (PlayerPrefs.HasKey(BGMVolumeOptionName))
        {
            BgsVolume = PlayerPrefs.GetFloat(BGMVolumeOptionName);
        }
        if (PlayerPrefs.HasKey(BGSVolumeOptionName))
        {
            BgsVolume = PlayerPrefs.GetFloat(BGSVolumeOptionName);
        }
    }

    void Update()
    {
        SetGeneralVolume(GeneralVolume);
        if (!BgsPlayer.isPlaying)
        {
            BgsPlayer.clip = BGS;
            BgsPlayer.Play();
            SetBGSVolume(BgsVolume);
        }
        if (!BgmPlayer.isPlaying && !bWaitForBGM)
        {
            StartCoroutine(Waiter(Random.Range(MinimumTimeBeforeNextBGM, MaximumTimeBeforeNextBGM)));
        }
    }
    //Fonctions pour changer le volume du son
    public void SetGeneralVolume(float GeneralVolume)
    {
        AudioListener.volume = GeneralVolume;
    }
    public void SetBGMVolume(float BgmVolume)
    {
        BgmPlayer.volume = BgmVolume;
    }

    public void SetBGSVolume(float BgsVolume)
    {
        BgsPlayer.volume = BgsVolume;
    }

    //Fonction pour jouer une musique
    public void PlayMusic(AudioClip BGM)
    {
        StartCoroutine(FadeAudioVolume(BgmPlayer, BgmFadeInDuration));
        BgmPlayer.clip = BGM;
        BgmPlayer.Play();
        SetBGMVolume(BgmVolume);
        bWaitForBGM = false;
    }


    //Sélectionne une musique aléatoire dans la playlist
    public AudioClip GetRandomBGM()
    {
        return BgmPlaylist[Random.Range(0, BgmPlaylist.Length)];
    }

    //Contrôle le fondu de l'audio
    IEnumerator FadeAudioVolume(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0f;
        float timer = 0f;
        float currentVolume = audioSource.volume;
        float targetValue = Mathf.Clamp(BgmVolume, 0f, 1f);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            audioSource.volume = newVolume;
            yield return null;
        }
    }

    //Contrôle le temps d'attente entre les musiques
    IEnumerator Waiter(int waitTime)
    {
        bWaitForBGM = true;
        yield return new WaitForSeconds(waitTime);
        PlayMusic(GetRandomBGM());
    }


}
