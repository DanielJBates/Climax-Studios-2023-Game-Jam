using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDictionary 
{
    private static ColourDictionary instance;
    Dictionary<string, Color> colourDict;

    private ColourDictionary() {
        colourDict = new()
        {
            { "Blue", new Color(0.327f, 0.7867f, 1f) },
            { "Red", new Color(1f, 0.3516f, 0.3254f) },
            { "Green", new Color(0.5251f, 1f, 0.5444f) },
            { "Cyan", new Color(0, 1, 0.8808f) },
            { "Orange", new Color(0.9905f, 0.7894f, 0.38f) },
            { "Yellow", new Color(0.991f, 1f, 0.393f) },
            { "Magenta", new Color(0.8766f, 0.3295f, 0.9528f) },
            { "Black", new Color(0,0,0) }
        };
    }

    public static ColourDictionary Instance
    {
        get
        {
            instance ??= new ColourDictionary();
            return instance;
        }
    }

    public Color GetColour(string name)
    {
        if (colourDict.TryGetValue(name, out var color))
        {
            return color;
        }
        return Color.black;
    }

    public void AddColor(string name, Color color)
    {
        colourDict.Add(name, color);
    }
}
