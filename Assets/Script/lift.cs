using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 8f;
    bool isup = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isup)
        {
            transform.Translate(Vector3.up * movespeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * movespeed * Time.deltaTime);
        }
        if (transform.position.y >= 11.07) isup = false;
        if (transform.position.y <= 4.57) isup = true;
    }
}
