using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    private static GameEvents _instance;

    static GameEvents() { }
    public static GameEvents Instance
    {
        get
        {
            _instance ??= new GameEvents();
            return _instance;
        }
    }

    private GameEvents() { }

    public static event Action onPlayerDeath;
    public void PlayerDied()
    {
        onPlayerDeath?.Invoke();
    }

    public static event Action onStart;

    public void StartGame()
    {
        onStart?.Invoke();
    }

    public static event Action onQuit;
    public void QuitGame()
    {
        onQuit?.Invoke();
    }

    public static event Action onColourChange;
    public void ChangeColour()
    {
        onColourChange?.Invoke();
    }

    public static event Action<GameObject> onCupcakePickup;
    public void PickedUpCupcake(GameObject go)
    {
        onCupcakePickup?.Invoke(go);
    }

    public static event Action onFinishedLevel;
    public void FinishLevel()
    {
        onFinishedLevel?.Invoke();
    }

    public static event Action onContinueSummary;
    public void ContinueFromSummary()
    {
        onContinueSummary?.Invoke();
    }

    public static event Action onFinishedGame;
    public void FinishedGame()
    {
        onFinishedGame?.Invoke();
    }

    public static event Action onCreditsCalled;
    public void CallCredits()
    {
        onCreditsCalled?.Invoke();
    }
}