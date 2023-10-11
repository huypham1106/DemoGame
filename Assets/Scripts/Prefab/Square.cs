using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Square : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image imgSquare;

    public TypeSquare colorSquare;

    private void Start()
    {
        
    }

    public void InitData(Vector3 mapPos)
    {
        
        int randomSprite = UnityEngine.Random.Range(0, sprites.Count);
        setColorData(randomSprite);
        imgSquare.sprite = sprites[randomSprite];
        this.transform.DOLocalMove(mapPos, 0f);
        this.gameObject.SetActive(true);
    }    

    private void setColorData(int index)
    {
        switch (index)
        {
            case 0:
                colorSquare = TypeSquare.Red;
                break;
            case 1:
                colorSquare = TypeSquare.Green;
                break;
            case 2:
                colorSquare = TypeSquare.Blue;
                break;
            case 3:
                colorSquare = TypeSquare.Yellow;
                break;
            case 4:
                colorSquare = TypeSquare.Orange;
                break;
        }    
    }    

}
