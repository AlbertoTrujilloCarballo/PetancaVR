using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] public float countdownTime = 180f;

    private bool gameRunning;

    void Start()
    {
    }

    void Update()
    {
        if (gameRunning)
        {
            countdownTime -= Time.deltaTime;

            //if (countdownTime <= 0)
            //{
            //    countdownTime = 0;
            //    gameRunning = false;
            //}

            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);

            string timeText = minutes.ToString("00") + ":" + (seconds == 60 ? "00" : seconds.ToString("00"));

            GameObject.Find("Timer").GetComponent<TMP_Text>().text = timeText;
        }
    }

    public void StopTimer()
    {
      gameRunning = false;
    }

    public void StartTimer()
    {
        gameRunning = true;
    }
}
