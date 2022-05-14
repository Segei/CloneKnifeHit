using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLose : MonoBehaviour
{
    [SerializeField] private Canvas _interface;
    [SerializeField] private Canvas _menuLose;
    private void Awake()
    {
        GlobalProperty.Lose.AddListener(() =>
        {
            StartCoroutine(EndGame());
        });
    }
    

    private IEnumerator EndGame()
    {
        yield return new WaitForSecondsRealtime(1);
        _interface.gameObject.SetActive(false);
        _menuLose.gameObject.SetActive(true);
        Debug.Log("You Lose!!");
        yield return null;
    }
}
