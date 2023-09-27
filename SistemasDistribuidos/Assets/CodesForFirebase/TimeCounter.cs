using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplay;

    public static TimeCounter instance;

    float currentTime = 0f;
    public int totalScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        totalScore = (int)(Mathf.Round(currentTime));

        timeDisplay.text = $"{totalScore}";
    }

    public void Restart()
    {
        currentTime = 0f;
    }
}
