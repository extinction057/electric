using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasPrefab;
    GameObject StartAnime;
    public string nowLevel;
    public string nextLevel;
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
        if (col.gameObject.CompareTag("NextLevel"))
        {
            Debug.Log("next");
            nextGame();
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
    public void nextGame()
    {
        StartAnime = (GameObject)Instantiate(canvasPrefab, canvasPrefab.transform.position, canvasPrefab.transform.rotation);
        Invoke("destroyB", 1.5f);
    }
    void destroyB()
    {
        //        transform.position = startPostion;
        SceneManager.LoadScene(nextLevel);
        //   SceneManager.LoadScene("Loading");
        Destroy(StartAnime);
    }
}
