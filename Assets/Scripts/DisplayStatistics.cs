using System;
using UnityEngine;
using TMPro;
public class DisplayStatistics : MonoBehaviour
{
    public static DisplayStatistics Instance;
    [SerializeField]
    private TextMeshProUGUI throwForceText, timeText, passedText;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(gameObject);

        Actions.OnFinish += SaveBestTime;    
    }
    private void SaveBestTime()
    {
       PlayerPrefs.SetString("bestTime", timeText.text);
    }
    public void ShowThrowForce(float throwForce)
    {
        throwForceText.text = $"Сила Натяжения: {String.Format("{0:0}", throwForce*100)}%";
    }

    public void ShowPassed(float passed)
    {
        passedText.text = $"Пройдено: {String.Format("{0:0}", passed*100)}%";
    }

    public void ShowTime(float time)
    {
        timeText.text = $"Время: {String.Format("{0:0.0000}", time)}";
    }
}
