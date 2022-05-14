using UnityEngine;
using UnityEngine.Events;

public class AppleCounter : MonoBehaviour
{
    public UnityEvent<int> UpdateCountApple;
    private void Awake()
    {
        GlobalProperty.AppleCounter = this;
    }
    private void Start()
    {
        UpdateCountApple?.Invoke(GlobalProperty.Apple);
    }
    public void AddApple()
    {
        GlobalProperty.Apple++;
        UpdateCountApple?.Invoke(GlobalProperty.Apple);
    }
    public bool TryGetApple(int countGet)
    {
        if (GlobalProperty.Apple - countGet < 0)
        {
            return false;
        }

        GlobalProperty.Apple -= countGet;
        UpdateCountApple?.Invoke(GlobalProperty.Apple);
        return true;
    }
}
