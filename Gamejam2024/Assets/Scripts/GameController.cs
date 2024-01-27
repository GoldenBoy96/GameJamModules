using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{

    public Transform enermyParent;
    public List<GameObject> enermyPrefabs;
    private List<string> enermyPrefabTag;
    public List<ObjectPool> enermyPools;
    public GameObject giftCatPrefab;

    public int score = 0;
    public string memeState = "HappyCat";

    public readonly string HappyCat = "HappyCat";
    public readonly string ChipiChapa = "ChipiChapa";
    public readonly string SmurfCat = "SmurfCat";


    private static GameController instance;
    private float nextSongDuration;

    private GameController()
    {

    }

    void Awake()
    {
        enermyPools = new();
        enermyPrefabTag = new();
        foreach (GameObject enermy in enermyPrefabs)
        {
            ObjectPool pool = gameObject.AddComponent<ObjectPool>();
            pool.CreatePool(enermy, 200, enermyParent);
            enermyPools.Add(pool);
            enermyPrefabTag.Add(enermy.gameObject.tag);
            Debug.Log(enermy.gameObject.tag);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    public static GameController Instance { get; private set; }
    public int Score { get => score; set => score = value; }


    private void Start()
    {
        StartCoroutine(ChangeState(true));
    }
    public void PushToPool(int poolIndex, GameObject gameObject)
    {
        //Debug.Log("Test   " + gameObject.tag);
        //Debug.Log(enermyPrefabTag.IndexOf(gameObject.tag));
        enermyPools[poolIndex].Push(gameObject);
    }

    public bool isPlaying = true;
    public int state;
    private IEnumerator ChangeState(bool isFirstTime)
    {
        if (isPlaying)
        {
             state = Random.Range(0, enermyPrefabs.Count - 1);
            while (state == enermyPrefabTag.IndexOf(memeState))
            {
                state = Random.Range(0, enermyPrefabs.Count);
            }
            //Debug.Log("ChangeState " + state + " | " + enermyPrefabTag.IndexOf(memeState));
            switch (state)
            {
                case 0:
                    AudioController.Instance.ChangeToAudio(0);
                    if (!isFirstTime) yield return new WaitForSeconds(1f);
                    memeState = HappyCat;
                    break;
                case 1:
                    AudioController.Instance.ChangeToAudio(1);
                    if (!isFirstTime) yield return new WaitForSeconds(1f);
                    memeState = ChipiChapa;
                    break;
                case 2:
                    AudioController.Instance.ChangeToAudio(2);
                    if (!isFirstTime) yield return new WaitForSeconds(1f);
                    memeState = SmurfCat;
                    break;
            }
            nextSongDuration = Random.Range(5f, 6f);
            yield return new WaitForSeconds(nextSongDuration);
            StartCoroutine(ChangeState(false));
        }

    }
}
