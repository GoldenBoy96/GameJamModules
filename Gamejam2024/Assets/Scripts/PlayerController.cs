using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject deadScreen;
    Vector3 mousePosition;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    public int hearts = 3;

    public List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomSkin();
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

    public bool isInvincible = false;

    private void RandomSkin()
    {
        int skinIndex = Random.Range(0, sprites.Count);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[skinIndex];
    }
    public IEnumerator SetInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag(GameController.Instance.memeState))
        {
            switch (GameController.Instance.memeState)
            {
                case "HappyCat":
                    GameController.Instance.PushToPool(0, collision.gameObject);
                    AudioController.Instance.PlayCollectionSound();
                    break;
                case "ChipiChapa":
                    GameController.Instance.PushToPool(1, collision.gameObject);
                    AudioController.Instance.PlayCollectionSound();
                    break;
                case "SmurfCat":
                    GameController.Instance.PushToPool(2, collision.gameObject);
                    AudioController.Instance.PlayCollectionSound();
                    break;
                case "Maxwell":
                    GameController.Instance.PushToPool(3, collision.gameObject);
                    AudioController.Instance.PlayCollectionSound();
                    break;
            }
            GameController.Instance.Score++;
            if (GameController.Instance.Score > GameManager.Instance.HighestScore)
            {
                GameManager.Instance.HighestScore = GameController.Instance.Score;
            }
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
                    AudioController.Instance.PlayHurtSound();
                    CameraShake.Shake(2f, 2f);
                    EventManager.Instance.InvokeLostHeart();
                    StartCoroutine(SetInvincible());
                    RandomSkin();
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
