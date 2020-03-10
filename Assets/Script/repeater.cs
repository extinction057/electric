using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeater : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ishandle;
    public bool canhandle;
    public bool canhandlef;
    public Transform parentTran;
    void Start()
    {
        
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ishandle&&canhandlef)
        {
 //           transform.SetParent(parentTran);
            transform.Find("head").gameObject.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canhandle = false;
            transform.localPosition = new Vector3(1.32f, 0.779f, 0);
        }
        else
        {
 //           transform.SetParent(null);
            transform.Find("head").gameObject.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            canhandle = true;
        }
    }
}
