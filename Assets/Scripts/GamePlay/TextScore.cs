using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextScore : MonoBehaviour
{
    public float countDuration = 1;
    Text numberText;
    float currentValue = 0, targetValue = 0;
    Coroutine _C2T;
    private const int scoreOneSquare = 50;

    void Awake()
    {
        numberText = GetComponent<Text>();
    }



    void Start()
    {
        currentValue = float.Parse(numberText.text);
        targetValue = currentValue;
    }

    public void resetScore()
    {
        currentValue = 0;
        targetValue = 0;
    }

    public string getFinalScore()
    {
        return targetValue.ToString();
    }

    IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
            numberText.text = ((int)currentValue).ToString();
            yield return null;
        }
    }



    public void AddValue(int  amountSquare)
    {
        int score = amountSquare * scoreOneSquare;
        if(amountSquare >=5)
        {
            score += 200;
        }

        targetValue += score;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }

    public void SetTarget(float target)
    {
        targetValue = target;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }
}
