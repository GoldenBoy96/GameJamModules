using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
        StartCoroutine(ActivateShield());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void FixedUpdate()
    {
    }

    public IEnumerator SetInvincible()
    {
        if (player != null)
        {
            player.GetComponent<PlayerController>().isInvincible = true ;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<PlayerController>().isInvincible = false;
            AudioController.Instance.PlayShieldBreakSound();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerController>().isInvincible = true;
        }
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GiftCat") && !collision.gameObject.CompareTag("Shield"))
        {
            if (!collision.gameObject.CompareTag(GameController.Instance.memeState))
            {
                switch (GameController.Instance.memeState)
                {
                    case "HappyCat":
                        GameController.Instance.PushToPool(0, collision.gameObject);
                        StartCoroutine(SetInvincible());
                        break;
                    case "ChipiChapa":
                        GameController.Instance.PushToPool(1, collision.gameObject);
                        StartCoroutine(SetInvincible());
                        break;
                    case "SmurfCat":
                        GameController.Instance.PushToPool(2, collision.gameObject);
                        StartCoroutine(SetInvincible());
                        break;
                    case "Maxwell":
                        GameController.Instance.PushToPool(3, collision.gameObject);
                        StartCoroutine(SetInvincible());
                        break;
                }
            }
        }

    }

    IEnumerator ActivateShield()
    {
        yield return new WaitForSeconds(20f);
        if (player != null)
        {
            StartCoroutine(SetInvincible());
        }

        AudioController.Instance.PlayShieldBreakSound();
        Destroy(gameObject);
    }
}
