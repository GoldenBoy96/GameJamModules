using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerController;
    public GameObject HealthBar;
    public GameObject Heart;
    List<Transform> heartFullList = new List<Transform>();
    public GameObject Score;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
        for (int i = 0; i < playerController.hearts; i++)
        {
            GameObject heart = Instantiate(Heart, HealthBar.transform);
            heartFullList.Add(heart.transform.Find("HeartFull"));
            
        }
        //scoreText = Score.GetComponent<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        
    }

    public void LostHeart()
    {
        for (int i = heartFullList.Count - 1; i >= playerController.hearts; i--)
        {
            heartFullList[i].gameObject.SetActive(false);
        }
    }

    public void GainScore()
    {
        scoreText.SetText("Score: " + GameController.Instance.Score);
    }
}
