using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="ScriptableObjects/Palette", order =1)]
public class PaletteScriptableObject : ScriptableObject
{
    public List<string> CurrentPalette;
}
