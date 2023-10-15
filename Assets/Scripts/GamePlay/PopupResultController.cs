using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PopupResultController : MonoBehaviour
{

    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtBestScore;
    [SerializeField] private Text txtTime;
    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnNextLevel;
    [SerializeField] private Button btnReplay;


    private Action onClickNextLevel;
    private Action onClickReplay;
    private void Awake()
    {
        btnHome.onClick.AddListener(onClickBtnHome);
        btnNextLevel.onClick.AddListener(onClickBtnNextLevel);
        btnReplay.onClick.AddListener(onClickBtnReplay);
    }

    public void ShowPopup(bool isWin, string score, string time = "" )
    {
        this.gameObject.SetActive(true);
        if(isWin)
        {
            SoundManager.I.PlaySFX(Global.SoundName.Hardest_LV_Win);
            txtTitle.text = "YOU WIN";
            Utilities.setTextColor(txtTitle, 0f, 154f, 42f, 255f);
            Utilities.setTextColor(txtScore, 0f, 255f, 70f, 255f);
            txtBestScore.transform.parent.gameObject.SetActive(true);
            txtBestScore.text = UserData.Instance.BestScore.ToString();
            txtTime.transform.parent.gameObject.SetActive(true);
            txtTime.text = time;
            btnNextLevel.gameObject.SetActive(true);
        }   
        else
        {
            SoundManager.I.PlaySFX(Global.SoundName.Hardest_LV_time_up);
            txtTitle.text = "YOU LOSE";
            Utilities.setTextColor(txtTitle, 154f, 21f, 0f, 255f);
            Utilities.setTextColor(txtScore, 255f, 0f, 0f, 255f);
            btnNextLevel.gameObject.SetActive(false);
            txtTime.transform.parent.gameObject.SetActive(false);
            txtBestScore.transform.parent.gameObject.SetActive(false);
        }
        txtScore.text = score;

    }
    
    private void onClickBtnHome()
    {
        SoundManager.I.PlaySFX(Global.SoundName.Hardest_btn_pop);
        SceneManager.LoadScene(Global.SceneName.s_mainMenu);
    }
    private void onClickBtnNextLevel()
    {
        SoundManager.I.PlaySFX(Global.SoundName.Hardest_btn_pop);
        GamePlayScene.Instance.onClickNextLevel();
    }
    private void onClickBtnReplay()
    {
        SoundManager.I.PlaySFX(Global.SoundName.Hardest_btn_pop);
        GamePlayScene.Instance.onClickReplay();
    }
}
