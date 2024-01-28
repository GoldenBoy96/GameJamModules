using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ToSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalModel");
    }

    public static void ExitApp()
    {
        Application.Quit();
    }
}
