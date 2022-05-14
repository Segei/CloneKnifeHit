using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "GameSceneManager", order =1)]
public class GameSceneManager : ScriptableObject
{
        
    public void Restart()
    {
        GlobalProperty.Apple = 0;
        GlobalProperty.Wave = 0;
        GlobalProperty.KnifeStore = 0;
        SceneManager.LoadScene(0);
        Debug.Log("Restart");
    }
    public void NextRound()
    {
        GlobalProperty.Wave++;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
