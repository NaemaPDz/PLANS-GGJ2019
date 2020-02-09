using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("QUIT");
        Application.Quit();
    }
}
