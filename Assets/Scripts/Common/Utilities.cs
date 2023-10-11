using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utilities
{

    public static void ClearTransform(Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public static void SetAlpha(float alphaValue, Image image)
    {
        Color newColor = image.color;
        newColor.a = alphaValue / 255f; ;
        image.color = newColor;
    }
}
