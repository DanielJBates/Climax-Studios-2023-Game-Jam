using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI collectedTitle;

    [SerializeField]
    Button creditsButton;

    void Start()
    {
        var totalCollected = GameManager.TOTAL_CUPCAKES;
        var totalPossible = 10;
        string[] bowStatus = { "very sad...", "sad.", "happy.", "very happy!" };
        int idx = Mathf.FloorToInt((float)(totalCollected / (float)(totalPossible + 1)) * 4);
        var status = bowStatus[idx];
        collectedTitle.text = "You collected: " + totalCollected + "/" + totalPossible + "  Cupcakes\n" + "Bow is " + status;

        creditsButton.onClick.AddListener(GameEvents.Instance.CallCredits);

        GameEvents.onCreditsCalled += GameEvents_onCreditsCalled;
        GameEvents.onQuit += GameEvents_onQuit;
    }

    private void GameEvents_onQuit()
    {
        Application.Quit();
    }

    private void GameEvents_onCreditsCalled()
    {
        SceneManager.LoadScene(7);
    }
}
