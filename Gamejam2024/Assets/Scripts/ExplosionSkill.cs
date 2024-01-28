using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkill : MonoBehaviour
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
            player.GetComponent<PlayerController>().isInvincible = true;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<PlayerController>().isInvincible = false;
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + " | ");
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerController>().isInvincible = true;
        }
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GiftCat") && !collision.gameObject.CompareTag("Shield"))
        {
            if (collision.gameObject.CompareTag(GameController.Instance.memeState))
            {
                GameController.Instance.score++;
                EventManager.Instance.InvokeGainScore();
                switch (GameController.Instance.memeState)
                {
                    case "HappyCat":
                        GameController.Instance.PushToPool(0, collision.gameObject);
                        break;
                    case "ChipiChapa":
                        GameController.Instance.PushToPool(1, collision.gameObject);
                        break;
                    case "SmurfCat":
                        GameController.Instance.PushToPool(2, collision.gameObject);
                        break;
                    case "Maxwell":
                        GameController.Instance.PushToPool(3, collision.gameObject);
                        break;
                }
            }
            else
            {
                switch (GameController.Instance.memeState)
                {
                    case "HappyCat":
                        GameController.Instance.PushToPool(0, collision.gameObject);
                        break;
                    case "ChipiChapa":
                        GameController.Instance.PushToPool(1, collision.gameObject);
                        break;
                    case "SmurfCat":
                        GameController.Instance.PushToPool(2, collision.gameObject);
                        break;
                    case "Maxwell":
                        GameController.Instance.PushToPool(3, collision.gameObject);
                        break;
                }
            }


        }

    }

    IEnumerator ActivateShield()
    {
        AudioController.Instance.PlayExplosionSound();
        yield return new WaitForSeconds(0.5f);
        if (player != null)
        {
            player.GetComponent<PlayerController>().isInvincible = true;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<PlayerController>().isInvincible = false;
            //Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
