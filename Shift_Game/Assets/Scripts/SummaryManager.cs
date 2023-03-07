using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SummaryManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI cupcakeCount;
    [SerializeField]
    TextMeshProUGUI happiness;

    AsyncOperation loadNextLevel;

    [SerializeField]
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        cupcakeCount.text = GameManager.CUPCAKE_COUNT.ToString();
        happiness.text = ((int)((GameManager.CUPCAKE_COUNT / 3.0f) * 100.0f)).ToString() + "%";
        loadNextLevel = SceneManager.LoadSceneAsync(GameManager.LEVEL + 3);
        loadNextLevel.allowSceneActivation = false;
        continueButton.onClick.AddListener(GameEvents.Instance.ContinueFromSummary);
        GameEvents.onContinueSummary += GameEvents_onContinueSummary;
        GameEvents.onQuit += GameEvents_onQuit;
    }

    private void GameEvents_onQuit()
    {
        Application.Quit();
    }

    private void GameEvents_onContinueSummary()
    {
        loadNextLevel.allowSceneActivation = true;
    }
}
