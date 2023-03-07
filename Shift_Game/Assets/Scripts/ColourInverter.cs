using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColourInverter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodySR;
    private SpriteRenderer bowSR;

    private void Start()
    {
        bowSR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Color body = bodySR.color;
        Color bow;

        if (body.CompareRGB(new Color(1.0f, 1.0f, 1.0f, 1.0f)))
        {
            bow = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            bow = new Color(1.0f - body.r, 1.0f - body.g, 1.0f - body.b, 1.0f);
        }

        bowSR.color = bow;
    }
}
