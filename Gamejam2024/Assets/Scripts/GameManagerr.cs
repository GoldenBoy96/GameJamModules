using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerr : MonoBehaviour
{
    private static GameManagerr instance;
    [SerializeField]private int highestScore = 0;

    private GameManagerr()
    {

    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }
   public static GameManagerr Instance {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(GameManagerr)) as GameManagerr;

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public int HighestScore { get => highestScore; set => highestScore = value; }
}
