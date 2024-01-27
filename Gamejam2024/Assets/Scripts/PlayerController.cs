using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject deadScreen;
    Vector3 mousePosition;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    public int hearts = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

    bool isInvincible = false;

    IEnumerator SetInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + " | " + GameController.Instance.memeState);
        if (collision.gameObject.CompareTag(GameController.Instance.memeState))
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
            }
            GameController.Instance.Score++;
            EventManager.Instance.InvokeGainScore();
            //Debug.Log("Score: " + GameController.Instance.Score);
        }
        else if (collision.gameObject.CompareTag("GiftCat"))
        {
            GiftCatMovement giftCatMovement = collision.gameObject.GetComponent<GiftCatMovement>();
            giftCatMovement.SummonBuff(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Shield"))
        {
            if (!isInvincible)
            {
                if (hearts > 1)
                {
                    hearts--;
                    CameraShake.Shake(2f, 2f);
                    EventManager.Instance.InvokeLostHeart();
                    StartCoroutine(SetInvincible());
                    return;
                }
                else
                {
                    Debug.Log("Gameover");
                    hearts--;
                    CameraShake.Shake(2f, 2f);
                    EventManager.Instance.InvokeLostHeart();
                    AudioController.Instance.StopAudio();
                    //Time.timeScale = 0f;
                    GameController.Instance.isPlaying = false;
                    Instantiate(deadScreen);
                    gameObject.SetActive(false);
                }
            }


        }
    }

    public void LostHeart()
    {
        //Debug.Log("Test event from Player");
    }

}
