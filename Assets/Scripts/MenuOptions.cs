using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void ChangeVolume(float volumen)
    {
        _audioMixer.SetFloat("Volumen", volumen);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}