using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimesUpUI : MonoBehaviour
{
    public TextMeshProUGUI timeover_text;
    public GameObject Panel;
    public ScoreSystem Score;
    public TextMeshProUGUI finalScore;

    // Start is called before the first frame update
    void Start()
    {
        Score = FindObjectOfType<ScoreSystem>();
        timeover_text.enabled = false;
        Panel.gameObject.SetActive(false);
        finalScore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
