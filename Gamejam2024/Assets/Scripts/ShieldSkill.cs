using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : MonoBehaviour
{
    public GameObject player;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GiftCat") && !collision.gameObject.CompareTag("Shield"))
        {
            if (!collision.gameObject.CompareTag(GameController.Instance.memeState))
            {
                switch (GameController.Instance.memeState)
                {
                    case "HappyCat":
                        GameController.Instance.PushToPool(0, collision.gameObject);
                        Destroy(gameObject);
                        break;
                    case "ChipiChapa":
                        GameController.Instance.PushToPool(1, collision.gameObject);
                        Destroy(gameObject);
                        break;
                    case "SmurfCat":
                        GameController.Instance.PushToPool(2, collision.gameObject);
                        Destroy(gameObject);
                        break;
                }
            }
        }
        
    }
}
