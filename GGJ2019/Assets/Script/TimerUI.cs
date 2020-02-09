using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    TimesUpUI timeups;
    public Button BackHome;
    public ScoreSystem Score;
    public TextMeshProUGUI finalScore;

    public bool GameHasEnded;
    public float TimeLeft = 60f;

    void Start()
    {
        Score = FindObjectOfType<ScoreSystem>();
        timeups = FindObjectOfType<TimesUpUI> ();
        GameHasEnded = false;
        BackHome.gameObject.SetActive(false);
        finalScore.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        string minutes = Mathf.Floor(TimeLeft / 60).ToString("00");
		string seconds = (TimeLeft % 60).ToString("00");
		text.text = minutes + ":" + seconds;

        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0f)
        {
            TimeLeft = 0f;
            if (!GameHasEnded)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        timeups.timeover_text.enabled = true;
        timeups.Panel.gameObject.SetActive(true);
        Time.timeScale = 0;
        BackHome.gameObject.SetActive(true);
        finalScore.enabled = true;
        finalScore.text = "Score = " + Score.home_score;
    }

    public void Continue()
    {
        SceneManager.LoadScene("End");
    }
}
