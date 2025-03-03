using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [Header("UI")]
    public TextMeshProUGUI timeText;
    [Space(10)]

    [Header("Time Variables")]
    [SerializeField] bool start = false;

    [SerializeField]float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            curTime += Time.deltaTime;
            ShowTime();
        }
    }

    void ShowTime()
    {
        int minutes = Mathf.FloorToInt(curTime / 60F);
        int seconds = Mathf.FloorToInt(curTime - minutes * 60);

        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeText.text = "Time: " + niceTime;
    }

    public float GetCurTime()
    {
        return curTime;
    }
}
