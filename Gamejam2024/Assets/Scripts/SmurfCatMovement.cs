using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmurfCatMovement : MonoBehaviour
{
    private float speed = 9.0f;
    private Vector3 dir = new Vector3(0.3f, 1f, 0f);
    private Vector3 rot = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    private void OnEnable()
    {
        int nature = Random.Range(0, 2);
        if (nature == 0)
        {
            dir = new Vector3(0.3f, 1f, 0f);
            rot = new Vector3(0f, 0f, 4f);
        }
        else
        {
            dir = new Vector3(-0.3f, 1f, 0f);
            rot = new Vector3(0f, 0f, -4f);
        }
    }


    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        transform.Rotate(rot * speed * Time.deltaTime);
    }

}
