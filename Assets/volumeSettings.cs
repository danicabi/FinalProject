using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Rendering;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    [SerializeField] Slider musisSlier;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider sfxSlider;
    
    public void Start(){
        setMusicVolume();
        setMasterVolume();
        setSFXVolume();
    }
    public void setMusicVolume(){
        float volum = musisSlier.value;
        myMixer.SetFloat("Music",Mathf.Log10(volum) * 20);
    }

    public void setMasterVolume(){
        float volum = masterSlider.value;
        myMixer.SetFloat("Master",Mathf.Log10(volum) * 20);
    }

    public void setSFXVolume(){
        float volum = sfxSlider.value;
        myMixer.SetFloat("sfx",Mathf.Log10(volum) * 20);
    }
}
