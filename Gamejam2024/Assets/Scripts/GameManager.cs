using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int highestScore = 0;

    private GameManager()
    {

    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    public static GameManager Instance { get; private set; }
    public int HighestScore { get => highestScore; set => highestScore = value; }
}
