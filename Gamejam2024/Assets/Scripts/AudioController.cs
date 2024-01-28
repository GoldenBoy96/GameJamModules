using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new();
    public AudioClip collectingSound;
    public AudioClip hurtSound;
    public AudioClip shieldBreakSound;
    public AudioClip explosionSound;
    public AudioClip healingSound;

    private static AudioController instance;
    private AudioController()
    {

    }

    void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
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
        //audioSource.Stop();
        //audioSource.clip = audioClips[index];
        //audioSource.Play();

        audioSource.DOFade(5f, 5f);
        audioSource.clip = audioClips[index];
        audioSource.time = Random.Range(0, 80) / 100 * audioSource.clip.length;
        audioSource.Play();

    }

    public void PlayCollectionSound()
    {
        //audioSource.pitch = Random.Range(0.5f, 1.5f);
        audioSource.PlayOneShot(collectingSound);
        //audioSource.pitch = 1;
    }
    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound);
    }
    public void PlayShieldBreakSound()
    {
        audioSource.PlayOneShot(shieldBreakSound);
    }
    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionSound);
    }
    public void PlayHealingSound()
    {
        audioSource.PlayOneShot(healingSound);
    }


}
