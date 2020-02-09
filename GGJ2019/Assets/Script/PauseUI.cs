using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static bool game_pausing;
    public Canvas PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!game_pausing)
            {
                game_pausing = true; 
                Time.timeScale = 0f;
                PauseMenu.enabled = true;
            }
            else
            {
                game_pausing = false;
                Time.timeScale = 1f;
                PauseMenu.enabled = false;
            }
        }
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("Home");
    }


}
