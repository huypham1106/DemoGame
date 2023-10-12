using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GamePlayScene : MonoBehaviour
{
    [Header("ConfigPopUp")]
    [SerializeField] private InputField ifHeight;
    [SerializeField] private InputField ifWidth;
    [SerializeField] private Button btnPlay;
    [SerializeField] private GameObject goCongigPopup;

    [Header("GamePlay")]
    //[SerializeField] private Square square;
    [SerializeField] private MapItem mapItem; 
    [SerializeField] private GameObject levelContent;
    [SerializeField] private ObjectPool poolSquare;

    private int width;
    private int height;
    private int indexMap;
    private List<MapItem> mapItemsList = new List<MapItem>();
    private List<Square> squareItemList = new List<Square>();
    private HashSet<Square> squareItemListChoose = new HashSet<Square>();
    private List<Square> squareItemListChooseTemp = new List<Square>();

    private void Awake()
    {
        btnPlay.onClick.AddListener(onClickPlay);
    }

    private void Start()
    {
        goCongigPopup.SetActive(true);
    }

    private void generateMap()
    {
        width = 0;
        height = 0;
        indexMap = -1;
        mapItemsList.Clear();

        if (ifWidth.text != null && ifHeight.text != null)
        {
            int.TryParse(ifWidth.text, out width);
            int.TryParse(ifHeight.text, out height);

            Utilities.ClearTransform(levelContent.transform);
            levelContent.transform.localScale = new Vector3(1f, 1f, 1f);


            if (width > 0 && height > 0)
            {
                int count = width * height;

                float posX = 0;
                float posY = 0;
                float a = mapItem.GetComponent<RectTransform>().rect.width;
                for (int i = 0; i < height; i++)
                {
                    posY = height * a * 1.0f / 2 - (i + 0.5f) * a * 1.0f;
                    for (int j = 0; j < width; j++)
                    {
                        posX = (j + 0.5f) * a * 1.0f - width * a * 1.0f / 2;

                        var copy = Instantiate(mapItem);
                        copy.transform.SetParent(levelContent.transform, false);
                        copy.transform.localPosition = new Vector3(posX, posY, 0f);
                        indexMap++;
                        copy.InitData((j), (i), indexMap);
                        mapItemsList.Add(copy);
                        if (i %2 == 0)
                        {
                            if (j % 2 == 0)
                            {
                                Utilities.SetAlpha(100f, mapItem.GetComponent<Image>());
                            }
                            else
                            {
                                Utilities.SetAlpha(180f, mapItem.GetComponent<Image>());
                            }
                        }  
                        else
                        {
                            if (j % 2 != 0)
                            {
                                Utilities.SetAlpha(100f, mapItem.GetComponent<Image>());
                            }
                            else
                            {
                                Utilities.SetAlpha(180f, mapItem.GetComponent<Image>());
                            }
                        }    
 
                    }
                }

                float widthContent = 50f * width;
                float heightContent = 50f * height;
                levelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(widthContent, heightContent);
            }

        }


    }

    private void generateSquare()
    {
        for(int i = 0; i < mapItemsList.Count; i++)
        {
           var squareItem = poolSquare.GetPooledObject();
           squareItem.GetComponent<Square>().InitData(mapItemsList[i], onClickSquareItem);
            squareItemList.Add(squareItem.GetComponent<Square>());
        }    
    }    

    private void onClickPlay()
    {
        goCongigPopup.SetActive(false);
        generateMap();
        generateSquare();
    }    

    /*private void onClickSquareItem(Square squareItem)
    {
        //height cột
        //width hàng
        
        // check item right
        for(int i = 1; i< height; i++)
        {
            if((squareItem.x + i) < height)
            {
                var squareTemp1 = squareItemList[squareItem.indexSquare + i];
                if (squareTemp1.typeSquare == squareItem.typeSquare)
                {
                    squareItemListChoose.Add(squareTemp1);                   
                }
                else
                {
                    break;
                }    
            }
            else
            {
                break;
            }    
        }

        // check item left
        for (int i = 1; i < height; i++)
        {
            if ((squareItem.x - i) >= 0)
            {
                var squareTemp2 = squareItemList[squareItem.indexSquare - i];
                if (squareTemp2.typeSquare == squareItem.typeSquare)
                {
                    squareItemListChoose.Add(squareTemp2);
                    
                }
                else
                {
                    break;
                }    
            }
            else
            {
                break;
            }
        }

        // check item Up

        for(int i = 1;i < width; i++)
        {
            if(squareItem.y - i >=0)
            {
                var squareTemp3 = squareItemList[squareItem.indexSquare - height * i];
                if (squareTemp3.typeSquare == squareItem.typeSquare)
                {
                    squareItemListChoose.Add(squareTemp3);                   
                }
                else
                {
                    break;
                }    
            }    
            else
            {
                break;
            }    
        }
        // check item Down

        for (int i = 1; i < width; i++)
        {
            if (squareItem.y + i < width)
            {
                var squareTemp4 = squareItemList[squareItem.indexSquare + height * i];
                if (squareTemp4.typeSquare == squareItem.typeSquare)
                {
                    squareItemListChoose.Add(squareTemp4);                   
                }
                else
                {
                    break;
                }    
            }
            else
            {
                break;
            }
        }
        if(squareItemListChoose.Count > 0) squareItemListChoose.Add(squareItem);
        Matching();
    }*/    

    private void onClickSquareItem(Square squareItem)
    {
        //var setQuet = new List<int>();
        squareItemListChooseTemp.Clear();
        squareItemListChooseTemp.Add(squareItem);
        squareItemListChoose.Clear();
        while (squareItemListChooseTemp.Count > 0)
        {
            Square itemTemp = squareItemListChooseTemp[0];
            squareItemListChooseTemp.RemoveAt(0);
            squareItemListChoose.Add(itemTemp);
            List<Square> keben = getSquareItemAround(itemTemp);
            foreach (var p in keben)
            {
                if (squareItemListChoose.Contains(p))
                {
                    continue;
                }
                if (!squareItemListChooseTemp.Contains(p))
                {
                    squareItemListChooseTemp.Add(p);
                };
            }
        }

        Matching();
    }    

    private List<Square> getSquareItemAround(Square squareItem)
    {
        List<Square> listSquare = new List<Square>();
        // right
        if ((squareItem.x + 1) < height)
        {
            var squareTemp1 = squareItemList[squareItem.indexSquare + 1];
            if (squareTemp1.typeSquare == squareItem.typeSquare)
            {
                listSquare.Add(squareTemp1);
            }
        }

        //left

        if ((squareItem.x - 1) >= 0)
        {
            var squareTemp2 = squareItemList[squareItem.indexSquare - 1];
            if (squareTemp2.typeSquare == squareItem.typeSquare)
            {
                listSquare.Add(squareTemp2);

            }
        }
        // up
        if (squareItem.y - 1 >= 0)
        {
            var squareTemp3 = squareItemList[squareItem.indexSquare - height];
            if (squareTemp3.typeSquare == squareItem.typeSquare)
            {
                listSquare.Add(squareTemp3);
            }
        }

        //down

        if (squareItem.y + 1 < width)
        {
            var squareTemp4 = squareItemList[squareItem.indexSquare + height];
            if (squareTemp4.typeSquare == squareItem.typeSquare)
            {
                listSquare.Add(squareTemp4);
            }

        }
        return listSquare;       
    }    

    private void Matching()
    {
        if(squareItemListChoose.Count >1)
        {
            foreach (var square in squareItemListChoose)
            {
                square.transform.DOScale(0f, 0.3f);
                square.typeSquare = TypeSquare.None;
            }
        }
        squareItemListChoose.Clear();
    }    
}
