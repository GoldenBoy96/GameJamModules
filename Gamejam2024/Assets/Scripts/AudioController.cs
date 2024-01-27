using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new();


    private static AudioController instance;
    private AudioController()
    {

    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public static AudioController Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
        //audioSource.clip = audioClips[0];
        //audioSource.PlayOneShot(RandomClip());
        audioSource.clip = audioClips[GameController.Instance.state];
        //audioSource.DOFade(0);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //public void ChangeToAudio()
    //{
    //    Debug.Log("Change Audio");
    //    audioSource.Stop();
    //    audioSource.PlayOneShot(RandomClip());
    //}

    AudioClip RandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Count)];
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void ChangeToAudio(int index)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
