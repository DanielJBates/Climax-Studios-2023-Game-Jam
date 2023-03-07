using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    AsyncOperation loadFirstLevel;

    void Start()
    {
        loadFirstLevel = SceneManager.LoadSceneAsync(3);
        loadFirstLevel.allowSceneActivation = false;
        GameEvents.onStart += GameEvents_onStart;
        GameEvents.onQuit += GameEvents_onQuit;
    }

    private void GameEvents_onStart()
    {
        loadFirstLevel.allowSceneActivation = true;
    }
    private void GameEvents_onQuit()
    {
        Application.Quit();
    }

}
