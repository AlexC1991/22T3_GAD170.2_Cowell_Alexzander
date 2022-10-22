using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexzanderCowell
{

}
public class FontScript : MonoBehaviour
{
    public Font[] fonts;
    // Fixes the font for the game so it's not blurry
    private void Awake()
    {
        for(int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }

}
