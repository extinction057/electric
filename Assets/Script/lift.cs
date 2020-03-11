using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 8f;
    bool isup = true;
    public float maxHeight;
    public float minHeight;
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
        if (transform.position.y >= maxHeight) isup = false;
        if (transform.position.y <= minHeight) isup = true;
    }
}
