using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCatMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector3 dir = Vector3.down;

    public GameObject Shield;

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
        GameObject shield = Instantiate(Shield);
        shield.GetComponent<ShieldSkill>().player = player;
        Destroy(gameObject);
    }
}
