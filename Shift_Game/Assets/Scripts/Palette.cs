using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    [HideInInspector]
    public PaletteScriptableObject CurrentPalette;

    public Color CurrentColour { get; private set; }

    private SpriteRenderer bodyRenderer;

    private int index = 0;

    public int Index { get { return index; } }

    public void SetPalette(PaletteScriptableObject value) {
        index = -1;
        CurrentPalette = value;
        NextColour();
    }

    public Color NextColour()
    {
        ++index;
        if (index == CurrentPalette.CurrentPalette.Count) { index = 0; }
        CurrentColour = ColourDictionary.Instance.GetColour(CurrentPalette.CurrentPalette[index]);
        return CurrentColour;
    }

    public Color QueryNextColour()
    {
        int temp = index;
        temp++;
        if (temp == CurrentPalette.CurrentPalette.Count) { temp = 0; }
        return ColourDictionary.Instance.GetColour(CurrentPalette.CurrentPalette[temp]);
    }

    private void Start()
    {
        bodyRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (bodyRenderer.color != CurrentColour)
        {
            bodyRenderer.color = CurrentColour;
            gameObject.layer = LayerMask.NameToLayer(CurrentPalette.CurrentPalette[index]);
        }
    }
}
