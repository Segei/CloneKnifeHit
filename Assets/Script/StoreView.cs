using UnityEngine;
using UnityEngine.Events;

public class StoreView : MonoBehaviour
{
    public UnityEvent<int> UpdateStore;

    private void Start()
    {
        UpdateStore?.Invoke(GetStore());
    }
    public void UpdateAplle(int apple)
    {
        UpdateStore?.Invoke(GetStore());
    }
    public void AddKnife()
    {
        GlobalProperty.KnifeStore++;
        UpdateStore?.Invoke(GetStore());
    }
    private int GetStore()
    {
        return GlobalProperty.KnifeStore + (GlobalProperty.Apple * 5);
    }
}
