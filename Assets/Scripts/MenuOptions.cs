using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void ChangeVolume(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
