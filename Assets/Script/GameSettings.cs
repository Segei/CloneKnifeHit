

using UnityEngine.Events;

public static class GameSettings
{
    //delete if don't use
    public static UnityEvent UpdateGameSetting = new UnityEvent();

    private static float _soundVolume = 1;
    public static float SoundVolume
    {
        get { return _soundVolume; }
        set
        {
            float soundVolume = value;
            soundVolume = (soundVolume >= 0 ? soundVolume : 0);
            soundVolume = (soundVolume <= 1 ? soundVolume : 1);
            _soundVolume = soundVolume;
            UpdateGameSetting?.Invoke();
        }
    }
    private static int _difficulty = 1;

    public static int Difficulty
    {
        get { return _difficulty; }
        set
        {
            _difficulty = value;
            UpdateGameSetting?.Invoke();
        }
    }
}
