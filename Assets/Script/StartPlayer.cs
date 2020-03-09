using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasPrefab;
    GameObject StartAnime;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        Debug.Log("sdasd");
        StartAnime = (GameObject)Instantiate(canvasPrefab, canvasPrefab.transform.position, canvasPrefab.transform.rotation);
        StartAnime.transform.SetParent(transform);
        Invoke("destroyA", 1.5f);
    }

    void destroyA()
    {
        Destroy(StartAnime);
    }
}
