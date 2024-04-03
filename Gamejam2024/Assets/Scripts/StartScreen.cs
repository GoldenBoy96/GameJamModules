using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject Game;
    public void StartGame()
    {
        Game.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
