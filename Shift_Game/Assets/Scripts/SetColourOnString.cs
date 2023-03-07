using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColourOnString : MonoBehaviour
{
    [SerializeField]
    string Colour;

    void Start()
    {
        if (Colour != "Default")
        {
            GetComponentInChildren<SpriteRenderer>().color = ColourDictionary.Instance.GetColour(Colour);
        }

        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer(Colour);
        }
        gameObject.layer = LayerMask.NameToLayer(Colour);
    }

}
