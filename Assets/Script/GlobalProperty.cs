using UnityEngine.Events;

public static class GlobalProperty 
{    
    public static KnifeController KnifeController;
    public static KnifeCounter KnifeCounter;
    public static AppleCounter AppleCounter;
    public static LogController LogController;
    public static Sounds Sounds;
    public static int Apple = 0;
    public static float GameSpeed = 1;
    public static UnityEvent Lose = new UnityEvent();
    public static int Wave = 0;
    public static int KnifeStore = 0;
}
