using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _appleHit;
    [SerializeField] private AudioSource _logHit;
    [SerializeField] private AudioSource _knifeHit;


    private void Awake()
    {
        GlobalProperty.Sounds = this;
    }
    private void Start()
    {
        SetVolumeSound();
        GameSettings.UpdateGameSetting.AddListener(SetVolumeSound);
    }
    public void PlayAppleHit() { _appleHit.Play(); }
    public void PlayLogHit() => _logHit.Play();
    public void PlayKnifeHit() => _knifeHit.Play();

    private void SetVolumeSound()
    {
        _appleHit.volume = GameSettings.SoundVolume;
        _logHit.volume = GameSettings.SoundVolume;
        _knifeHit.volume = GameSettings.SoundVolume;
    }
}
