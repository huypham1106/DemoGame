using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
public class TimeController : MonoBehaviour
{
    [SerializeField] public Text txtTime;

    private Coroutine startCountDown;

    private int time;
    private Action actionEndTime;
    public void InitData(int time, Action actionEndTime)
    {
        this.time = time;
        this.actionEndTime = actionEndTime;
        txtTime.text = time.ToString();
        startCountDown = StartCoroutine(StartCountdown());
    }    
    private IEnumerator StartCountdown()
    {
        float currentTime = time;

        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            if(currentTime <= 10)
            {
                SoundManager.I.PlaySFX(Global.SoundName.Hardest_guide_tap);
            }    
            txtTime.text = currentTime.ToString();
        }
        actionEndTime.Invoke();


    }

    public string getCurrentTime()
    {
        return txtTime.text;
    }    
    public void stopCountDown()
    {
        if(startCountDown != null)
        {
            StopCoroutine(startCountDown);
        }    
    }    

    private void EndOfTime()
    {
        Debug.Log("show result screen");
    }    
}
