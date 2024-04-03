using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxwellMovement : MonoBehaviour
{
    private float speed = 6.0f;
    private Vector3 dir = new Vector3(0.3f, 1f, 0f);
    // Start is called before the first frame update
    private void OnEnable()
    {
        int nature = Random.Range(0, 2);
        if (nature == 0)
        {
            dir = new Vector3(1.5f, 1f, 0f);
        }
        else
        {
            dir = new Vector3(-1.5f, 1f, 0f);
        }
        StartCoroutine(ResetNature());
    }

    private IEnumerator ResetNature()
    {
        dir.x = - dir.x;
        yield return new WaitForSeconds(1f);
        StartCoroutine(ResetNature());
    }


    void Start()
    {

        //StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
