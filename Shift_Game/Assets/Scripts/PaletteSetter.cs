using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteSetter : MonoBehaviour
{
    Palette _playerPalette;

    [SerializeField]
    PaletteScriptableObject _levelPalette;

    [SerializeField]
    Image currentColourUI;
    [SerializeField]
    Image nextColourUI;

    void Awake()
    {
        _playerPalette = FindObjectOfType<Palette>();
        if (_playerPalette == null) { return; }
        _playerPalette.SetPalette(_levelPalette);
        GameEvents.onColourChange += GameEvents_onColourChange;

        if (currentColourUI == null) { return; }
        currentColourUI.color = _playerPalette.CurrentColour;
        nextColourUI.color = _playerPalette.QueryNextColour();
    }

    private void GameEvents_onColourChange()
    {
        if (currentColourUI != null)
        {
            currentColourUI.color = _playerPalette.CurrentColour;
            nextColourUI.color = _playerPalette.QueryNextColour();
        }
    }
}
