using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCatMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector3 dir = Vector3.down;

    public GameObject Shield;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PushBackToPull());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void SummonBuff(GameObject player)
    {
        int skill = Random.Range(0, 3);
        switch (skill)
        {
            case 0:
                GameObject shield = Instantiate(Shield);
                shield.GetComponent<ShieldSkill>().player = player;
                Destroy(gameObject);
                break;
            case 1:
                GameObject explosion = Instantiate(Explosion);
                explosion.GetComponent<ExplosionSkill>().player = player;
                Destroy(gameObject);
                break;
                case 2:
                if (player.GetComponent<PlayerController>().hearts < 3)
                {
                    player.GetComponent<PlayerController>().hearts++;
                }
                AudioController.Instance.PlayHealingSound();
                EventManager.Instance.InvokeLostHeart();
                Destroy(gameObject);
                break;
        }

    }
}
