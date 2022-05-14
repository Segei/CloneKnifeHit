using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditGameSetting : MonoBehaviour
{
    public void ChangeVolumeSetting(float setting)
    {
        GameSettings.SoundVolume = setting;
    }
    
    public void ChangeDifficultySetting(float setting)
    {
        GameSettings.Difficulty = (int)setting;
    }
}
