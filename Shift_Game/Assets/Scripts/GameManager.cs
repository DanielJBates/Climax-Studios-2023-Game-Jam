using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int LEVEL = 0;
    public static int CUPCAKE_COUNT = 0;
    public static int TOTAL_CUPCAKES = 0;

    [SerializeField]
    RectTransform cupcakeUI;

    GameObject cupcakeUIImage;

    AsyncOperation loadSummary;

    private void Awake()
    {
        cupcakeUIImage = Resources.Load<GameObject>("Prefabs/CupcakeUIImage");
        //c1 = Resources.Load<Sprite>("../Art/c1");
        //c2 = Resources.Load<Sprite>("../Art/c2");
        //c3 = Resources.Load<Sprite>("../Art/c3");
        //c4 = Resources.Load<Sprite>("../Art/c4");
    }

    void Start()
    {
        CUPCAKE_COUNT = 0;
        GameEvents.onPlayerDeath += GameEvents_onPlayerDeath;
        GameEvents.onCupcakePickup += GameEvents_onCupcakePickup;
        GameEvents.onFinishedLevel += GameEvents_onFinishedLevel;
        GameEvents.onFinishedGame += GameEvents_onFinishedGame;
        GameEvents.onQuit += GameEvents_onQuit;
        loadSummary = SceneManager.LoadSceneAsync(2);
        loadSummary.allowSceneActivation = false;
    }

    private void GameEvents_onQuit()
    {
        Application.Quit();
    }

    private void GameEvents_onFinishedGame()
    {
        CUPCAKE_COUNT++;
        TOTAL_CUPCAKES += CUPCAKE_COUNT;
        SceneManager.LoadScene(6);
    }

    private void GameEvents_onFinishedLevel()
    {
        LEVEL++;
        TOTAL_CUPCAKES += CUPCAKE_COUNT;
        GameEvents.onPlayerDeath -= GameEvents_onPlayerDeath;
        GameEvents.onCupcakePickup -= GameEvents_onCupcakePickup;
        GameEvents.onFinishedLevel -= GameEvents_onFinishedLevel;
        GameEvents.onFinishedGame -= GameEvents_onFinishedGame;
        loadSummary.allowSceneActivation = true;
    }

    private void GameEvents_onCupcakePickup(GameObject obj)
    {
        var spriteRenderer = obj.GetComponent<SpriteRenderer>();
        var sprite = spriteRenderer.sprite;
        var newImage = Instantiate(cupcakeUIImage);
        newImage.GetComponent<Image>().sprite = sprite;
        newImage.transform.SetParent(cupcakeUI);

        var width = cupcakeUI.sizeDelta.x;
        var third = width * 0.333f;
        var childcount = cupcakeUI.childCount;
        var total = childcount * third;
        var spriteWidth = sprite.textureRect.width;
        var newX = total - width * 0.5f - spriteWidth * 0.5f;
        newImage.transform.localPosition = new Vector3(newX,0,0);
        ++CUPCAKE_COUNT;
        Destroy(obj);
    }

    private void GameEvents_onPlayerDeath()
    {
        GameEvents.onPlayerDeath -= GameEvents_onPlayerDeath;
        GameEvents.onCupcakePickup -= GameEvents_onCupcakePickup;
        GameEvents.onFinishedLevel -= GameEvents_onFinishedLevel;
        GameEvents.onFinishedGame -= GameEvents_onFinishedGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CUPCAKE_COUNT = 0;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F1))
    //    {
    //        GameEvents.onPlayerDeath -= GameEvents_onPlayerDeath;
    //        GameEvents.onCupcakePickup -= GameEvents_onCupcakePickup;
    //        GameEvents.onFinishedLevel -= GameEvents_onFinishedLevel;
    //        GameEvents.onFinishedGame -= GameEvents_onFinishedGame;
    //        SceneManager.LoadScene(3);
    //    }
    //    if (Input.GetKeyDown(KeyCode.F2))
    //    {
    //        GameEvents.onPlayerDeath -= GameEvents_onPlayerDeath;
    //        GameEvents.onCupcakePickup -= GameEvents_onCupcakePickup;
    //        GameEvents.onFinishedLevel -= GameEvents_onFinishedLevel;
    //        GameEvents.onFinishedGame -= GameEvents_onFinishedGame;
    //        SceneManager.LoadScene(4);
    //    }
    //    if (Input.GetKeyDown(KeyCode.F3))
    //    {
    //        GameEvents.onPlayerDeath -= GameEvents_onPlayerDeath;
    //        GameEvents.onCupcakePickup -= GameEvents_onCupcakePickup;
    //        GameEvents.onFinishedLevel -= GameEvents_onFinishedLevel;
    //        GameEvents.onFinishedGame -= GameEvents_onFinishedGame;
    //        SceneManager.LoadScene(5);
    //    }
    //    if (Input.GetKeyDown(KeyCode.F4))
    //    {
    //        GameObject.Find("Bow").GetComponent<Transform>().localPosition = new Vector3(-70.53f, 0.94f, 0.0f);
    //    }
    //}
}
