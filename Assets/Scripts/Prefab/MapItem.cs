using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    public int x;
    public int y;

    public void InitData(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
