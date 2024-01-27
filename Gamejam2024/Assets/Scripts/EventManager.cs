using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    UnityEvent lostHeart;
    UnityEvent gainScore;
    public GameObject Player;
    private PlayerController playerController;
    public GameObject UICanvas;
    private UIManager uiManager;

    private static EventManager instance;
    private EventManager() { }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<EventManager>();
        };
        DontDestroyOnLoad(gameObject);
    }
    public static EventManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
        uiManager = UICanvas.GetComponent<UIManager>();
        if (lostHeart == null)
            lostHeart = new UnityEvent();

        lostHeart.AddListener(uiManager.LostHeart);
        lostHeart.AddListener(playerController.LostHeart);
        if (gainScore == null)
            gainScore = new UnityEvent();

        gainScore.AddListener(uiManager.GainScore);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InvokeLostHeart()
    {
        lostHeart.Invoke();
    }

    public void InvokeGainScore()
    {
        gainScore.Invoke();
    }

    public void OnBecameInvisible()
    {

    }
}
