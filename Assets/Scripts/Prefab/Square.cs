using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Square : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image imgSquare;
    [SerializeField] private Button btnSquare;
    [SerializeField] public int x;
    [SerializeField] public int y;
    [SerializeField] public int indexSquare;

    private Action<Square> onClickSquare;
    private MapItem newMapItem;
    public TypeSquare typeSquare;

    private void Awake()
    {
        btnSquare.onClick.AddListener(onClickBtnSquare);
    }
    private void Start()
    {
        
    }

    public void InitData(MapItem mapItem, Action<Square> onClickSquare)
    {
        
        int randomSprite = UnityEngine.Random.Range(0, sprites.Count);
        setColorData(randomSprite);
        imgSquare.sprite = sprites[randomSprite];
        this.gameObject.SetActive(true);

        this.transform.SetParent(mapItem.transform);
        this.transform.localPosition = Vector3.zero;

        this.x = mapItem.x;
        this.y = mapItem.y;
        mapItem.square = this;
        this.indexSquare = mapItem.indexMap;
        this.onClickSquare = onClickSquare;
    }    

    public void setNewData(MapItem mapItem, bool isNeedRandom = false)
    {
        this.gameObject.SetActive(true);
        if (isNeedRandom)
        {
            int randomSprite = UnityEngine.Random.Range(0, sprites.Count);
            setColorData(randomSprite);
            imgSquare.sprite = sprites[randomSprite];
        }
        this.newMapItem = mapItem;
        this.x = mapItem.x;
        this.y = mapItem.y;
        mapItem.square = this;
        this.indexSquare = mapItem.indexMap;
        
    }   
    
    public void FallToMap(Vector3 initPos, float posY)
    {
        this.transform.DOMove(initPos, 0f).OnComplete(() =>
        {
            this.transform.DOScale(1f, 0f);
            this.transform.DOLocalMoveY(posY, 0.5f).OnComplete(()=>
            {
                this.transform.SetParent(newMapItem.transform);
                this.transform.localPosition = Vector3.zero;
            });
        });

    }   
    public void MoveToHole(MapItem mapItem)
    {
        this.transform.DOMove(mapItem.transform.position, 0.5f).OnComplete(() =>
        {
            this.transform.SetParent(mapItem.transform);
            this.transform.localPosition = Vector3.zero;

        });
    }    

    private void setColorData(int index)
    {
        switch (index)
        {
            case 0:
                typeSquare = TypeSquare.Red;
                break;
            case 1:
                typeSquare = TypeSquare.Green;
                break;
            case 2:
                typeSquare = TypeSquare.Blue;
                break;
            case 3:
                typeSquare = TypeSquare.Yellow;
                break;
            case 4:
                typeSquare = TypeSquare.Orange;
                break;
        }    
    }    

    private void onClickBtnSquare()
    {
        if (onClickSquare != null)
            onClickSquare.Invoke(this);
    }    

}
