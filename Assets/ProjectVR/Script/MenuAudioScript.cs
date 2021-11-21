using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioScript : MonoBehaviour
{
    [SerializeField] Slider BGMVolumeSlider;
    [SerializeField] Slider BGSVolumeSlider;
    [SerializeField] Slider GeneralVolumeSlider;
    [SerializeField] SoundManagerScript SoundManager;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(SoundManager.BGMVolumeOptionName))
        {
            PlayerPrefs.SetFloat(SoundManager.BGMVolumeOptionName, SoundManager.BgmVolume);
            LoadBGMVolume();
        }else
        {
            LoadBGMVolume();
        }

        if (!PlayerPrefs.HasKey(SoundManager.BGSVolumeOptionName))
        {
            PlayerPrefs.SetFloat(SoundManager.BGSVolumeOptionName, SoundManager.BgsVolume);
            LoadBGSVolume();
        }else
        {
            LoadBGSVolume();
        }

        if (!PlayerPrefs.HasKey(SoundManager.GeneralVolumeOptionName))
        {
            PlayerPrefs.SetFloat(SoundManager.GeneralVolumeOptionName, SoundManager.GeneralVolume);
            LoadGeneralVolume();
        }else
        {
            LoadGeneralVolume();
        }
    }

    //Update sound volume
    public void UpdateGeneralVolume()
    {
        SoundManager.SetGeneralVolume(GeneralVolumeSlider.value / GeneralVolumeSlider.maxValue);
        SoundManager.GeneralVolume = GeneralVolumeSlider.value / GeneralVolumeSlider.maxValue;
        SaveGeneralVolume();
    }
    public void UpdateBGMVolume()
    {
        SoundManager.SetBGMVolume(BGMVolumeSlider.value / BGMVolumeSlider.maxValue);
        SoundManager.BgmVolume = BGMVolumeSlider.value / BGMVolumeSlider.maxValue;
        SaveBGMVolume();
    }
    public void UpdateBGSVolume()
    {
        SoundManager.SetBGSVolume(BGSVolumeSlider.value / BGSVolumeSlider.maxValue);
        SoundManager.BgsVolume = BGSVolumeSlider.value / BGSVolumeSlider.maxValue;
        SaveBGSVolume();
    }

    //Load saved value
    private void LoadGeneralVolume()
    {
        GeneralVolumeSlider.value = PlayerPrefs.GetFloat(SoundManager.GeneralVolumeOptionName);
        UpdateGeneralVolume();
    }
    private void LoadBGMVolume()
    {
        BGMVolumeSlider.value = PlayerPrefs.GetFloat(SoundManager.BGMVolumeOptionName);
        UpdateBGMVolume();
    }
    private void LoadBGSVolume()
    {
        BGSVolumeSlider.value = PlayerPrefs.GetFloat(SoundManager.BGSVolumeOptionName);
        UpdateBGSVolume();
    }

    //Save sliders value
    private void SaveGeneralVolume()
    {
        PlayerPrefs.SetFloat(SoundManager.GeneralVolumeOptionName, GeneralVolumeSlider.value);
    }
    private void SaveBGMVolume()
    {
        PlayerPrefs.SetFloat(SoundManager.BGMVolumeOptionName, BGMVolumeSlider.value);
    }
    private void SaveBGSVolume()
    {
        PlayerPrefs.SetFloat(SoundManager.BGSVolumeOptionName, BGSVolumeSlider.value);
    }

    
}