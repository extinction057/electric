﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasPrefab;
    GameObject StartAnime;
    public string nowLevel;
    Vector3 startPostion;
    void Awake()
    {
        startPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Stab"))
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        StartAnime = (GameObject)Instantiate(canvasPrefab, canvasPrefab.transform.position, canvasPrefab.transform.rotation);
        Invoke("destroyA", 1.5f);
    }
    void destroyA()
    {
//        transform.position = startPostion;
        SceneManager.LoadScene(nowLevel);
     //   SceneManager.LoadScene("Loading");
        Destroy(StartAnime);
    }
    
}