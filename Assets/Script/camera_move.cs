using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject P1;
    public GameObject P2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (P1.transform.position + P2.transform.position)/2+new Vector3(0,0,-10);

    }
}
