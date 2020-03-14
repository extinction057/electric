using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    // Start is called before the first frame update
    bool isopen=false;
    public GameObject P1;
    public GameObject P2;
    public GameObject T1;
    public GameObject T2;
    public GameObject C1; 
    void Awake()
    {
    //    T1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey&&!isopen)
        {
            isopen = true;
            P1.SetActive(true);
            P2.SetActive(true);
            T1.AddComponent<WallExplode>();
            T2.AddComponent<WallExplode>();
            Destroy(C1);
        }
    }
}
