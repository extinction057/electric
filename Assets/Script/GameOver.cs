using System.Collections;
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
    public AudioSource SoundPlayer;
    void Awake()
    {
        startPostion = transform.position;
        SoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Stab"))
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/gameover");
            SoundPlayer.clip = clip;
            SoundPlayer.PlayOneShot(clip);
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
