using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NextWave : MonoBehaviour
{
    [SerializeField] private UnityEvent _nextWave;
    private bool _lose = false;

    private void Start()
    {
        GlobalProperty.LogController.HitOnLog.AddListener(() =>
        {
            if (GlobalProperty.KnifeCounter.CountKnife == 0)
            {
                StartCoroutine(NexWave());
            }
        });
        GlobalProperty.Lose.AddListener(()=> _lose = true);
    }
    private IEnumerator NexWave()
    {
        
        yield return new WaitForSecondsRealtime(1);
        if(!_lose)
            _nextWave?.Invoke();
        yield return null;
    }

}
