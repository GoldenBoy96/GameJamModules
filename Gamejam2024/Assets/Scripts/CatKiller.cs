using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatKiller : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatKiller"))
        {
            //Debug.Log("TESTTTTTTTTTTTTTTTTTTTTTTTTT");
            return;
        }
        //Debug.Log(collision.gameObject.tag);
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GiftCat") && !collision.gameObject.CompareTag("Shield"))
        {
            if (!collision.gameObject.CompareTag(GameController.Instance.memeState))
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
}
