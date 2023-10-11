using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Button btnPlay;

    private void Awake()
    {
        btnPlay.onClick.AddListener(onClickBtnPlay);
    }
    void Start()
    {
        init();
    }

    private void init()
    {
        
    }

    private void onClickBtnPlay()
    {
        SceneManager.LoadScene(Global.SceneName.s_gamePlay);
    }
}
