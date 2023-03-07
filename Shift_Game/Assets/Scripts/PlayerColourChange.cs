using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColourChange : MonoBehaviour
{
    bool pressed;
    Palette _playerPalette;
    void Start()
    {
        _playerPalette = GetComponent<Palette>();
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Switch Colour") != 0)
        {
            if (pressed) { return; }
            pressed = true;
            _playerPalette.NextColour();
            GameEvents.Instance.ChangeColour();
        }
        else
        {
            pressed = false;
        }
    }
}
