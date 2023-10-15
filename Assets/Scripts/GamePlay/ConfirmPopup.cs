using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmPopup : MonoBehaviour
{
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;

    private void Awake()
    {
        btnYes.onClick.AddListener(onClickYes);
        btnNo.onClick.AddListener(onClickNo);
    }

    public void OnShowConfirmPopup()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }    

    private void onClickYes()
    {
        Time.timeScale = 1;
        SoundManager.I.PlaySFX(Global.SoundName.Hardest_btn_pop);
        SceneManager.LoadScene(Global.SceneName.s_mainMenu);

    }
    private void onClickNo()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
