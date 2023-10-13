using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    public int x;
    public int y;
    public int indexMap;
    public Square square;
    public bool isEmpty;

    public void InitData(int x, int y, int indexMap)
    {
        this.x = x;
        this.y = y;
        this.indexMap = indexMap;
    }

    public void setSquare(Square squareItem)
    {
        this.square = squareItem;
        this.isEmpty = false;
    }    
}
