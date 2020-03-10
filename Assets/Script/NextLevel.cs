using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject canvasPrefab;
    GameObject StartAnime;
    public string nextLevel;
    int num=0;
    bool P1 = true;
    bool P2 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(num>=2)
        {
            nextGame();
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(col.gameObject.GetComponent<elect>().num==1&&P1)
            {
                num++;
                P1 = false;
            }
            if(col.gameObject.GetComponent<elect>().num == 2 && P2)
            {
                num++;
                P2 = false;
            }
        }
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
