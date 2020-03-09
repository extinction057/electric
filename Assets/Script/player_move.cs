using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float movespeed;
    public string keyL,keyR,keyU,keyD;
    bool canjump=false;
    bool canMove = false;
    Sprite img;
    float timestart=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //       Physics.gravity = new Vector3(0, -50, 0);
        //      img = Resources.Load("Sprite and Textures/玩家/TV_static/static1", typeof(Sprite)) as Sprite
        if (canMove)
        {
            if ((int)(Time.fixedTime-timestart) / 2 % 2 == 0)
            {
                img = Resources.Load("Sprite and Textures/玩家/TV_static/static1", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
            }
            else
            {
                img = Resources.Load("Sprite and Textures/玩家/TV_static/static2", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
            //        GetComponent<SpriteRenderer>().sprite = img;
            if (Input.GetKey(keyL))
            {
                Debug.Log("sad");
                img = Resources.Load("Sprite and Textures/玩家/TV_Run/Run2", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
                transform.Translate(Vector3.left * movespeed * Time.deltaTime);
                timestart = Time.fixedTime;
            }
            if (Input.GetKey(keyR))
            {
                img = Resources.Load("Sprite and Textures/玩家/TV_Run/Run2", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.Translate(Vector3.left * movespeed * Time.deltaTime);
                timestart = Time.fixedTime;
            }
            if (Input.GetKeyDown(keyU) && canjump)
            {
                Rigidbody2D rig = GetComponent<Rigidbody2D>();
                rig.AddForce(Vector3.up * 950f);
                canjump = false;
            }
            else
            {
               
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            canjump = true;
            canMove = true;
        }
    }

}
