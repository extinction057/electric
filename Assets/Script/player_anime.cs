using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_anime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dustPrefab;
    float landp;
    public float maxHeight=0;
    public bool heightCheck;
    GameObject dustanime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heightCheck)
        {
            if (transform.position.y > maxHeight) maxHeight = transform.position.y;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            landp= transform.position.y;
            if (maxHeight - landp >= 10) dustanime = Instantiate(dustPrefab, transform);
            if(dustanime!=null) dustanime.transform.localPosition = new Vector3(0.112f, -0.21f, 0);
            Invoke("destroyD", 1f);
            maxHeight = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            heightCheck = true;
        }
    }
    void destroyD()
    {
        Destroy(dustanime);
    }
}
