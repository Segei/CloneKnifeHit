using UnityEngine;
using UnityEngine.Events;

public class KnifeCounter : MonoBehaviour
{
    public UnityEvent<int> UpdateKnifeCount;
    [SerializeField] private int _countKnife = 7;
    public int CountKnife
    {
        get { return _countKnife; }
        set
        {
            _countKnife = value;
            UpdateKnifeCount?.Invoke(_countKnife);
        }
    }


    private void Awake()
    {
        GlobalProperty.KnifeCounter = this;
        _countKnife = 7 + (GameSettings.Difficulty * GlobalProperty.Wave);
        UpdateKnifeCount?.Invoke(_countKnife);
    }

    public void RunKnife()
    {
        if (CountKnife > 0)
            CountKnife--;
    }

}
