using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private List<MapItem> mapItems = new List<MapItem>();

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
        mapItems.Clear();

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
                        copy.InitData((j), (i));
                        mapItems.Add(copy);
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
        for(int i = 0; i < mapItems.Count; i++)
        {
           var squareItem = poolSquare.GetPooledObject();
            squareItem.GetComponent<Square>().InitData(mapItems[i].transform.localPosition);
        }    
    }    

    private void onClickPlay()
    {
        goCongigPopup.SetActive(false);
        generateMap();
        generateSquare();
    }    
}
