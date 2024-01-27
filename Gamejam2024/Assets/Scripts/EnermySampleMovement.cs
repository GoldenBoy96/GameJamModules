using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySampleMovement : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector3 dir = Vector3.up;
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

    
}
