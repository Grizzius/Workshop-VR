using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    [Header("Clips")]
    public AudioClip[] BgmPlaylist;
    public int MinimumTimeBeforeNextBGM;
    public int MaximumTimeBeforeNextBGM;
    bool bWaitForBGM;
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
    void Start()
    {
        BgmPlayer.loop = false;
        BgsPlayer.loop = true;
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

    public void ChangeGlobalVolume(float GlobalVolume)
    {
        AudioListener.volume = GlobalVolume;
    }

    private AudioClip GetRandomBGM()
    {
        return BgmPlaylist[Random.Range(0, BgmPlaylist.Length)];
    }

    IEnumerator Waiter(int waitTime)
    {
        bWaitForBGM = true;
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(waitTime);
        BgmPlayer.clip = GetRandomBGM();
        BgmPlayer.Play();
        SetBGMVolume(BgmVolume);
        bWaitForBGM = false;
    }
}
