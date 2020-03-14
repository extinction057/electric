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
    float timestart2 = 0;
    GameObject handleRepeater=null;
    bool jumpimgupdate=false;
    public AudioSource SoundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (canjump&&!jumpimgupdate)
            {
                if ((int)(Time.fixedTime - timestart) / 2 % 2 == 0)
                {
                    img = Resources.Load("Sprite and Textures/玩家/TV_static/static1", typeof(Sprite)) as Sprite;
                    GetComponent<SpriteRenderer>().sprite = img;
                }
                else
                {
                    img = Resources.Load("Sprite and Textures/玩家/TV_static/static2", typeof(Sprite)) as Sprite;
                    GetComponent<SpriteRenderer>().sprite = img;
                }
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (Input.GetKey(keyL))
            {
                if (canjump && !jumpimgupdate)
                {
                    img = Resources.Load("Sprite and Textures/玩家/TV_Run/Run2", typeof(Sprite)) as Sprite;
                    GetComponent<SpriteRenderer>().sprite = img;
                }
                if (handleRepeater != null) handleRepeater.GetComponent<repeater>().Rposition = new Vector3(-1.44f, 0.8f, 0);
                transform.Translate(Vector3.left * movespeed * Time.deltaTime);
                timestart = Time.fixedTime;
            }
            if (Input.GetKey(keyR))
            {
                if (canjump && !jumpimgupdate)
                {
                    img = Resources.Load("Sprite and Textures/玩家/TV_Run/Run3", typeof(Sprite)) as Sprite;
                    GetComponent<SpriteRenderer>().sprite = img;
                }
                if(handleRepeater!=null) handleRepeater.GetComponent<repeater>().Rposition= new Vector3(1.32f, 0.779f, 0); 
                transform.Translate(Vector3.right * movespeed * Time.deltaTime);
                timestart = Time.fixedTime;
            }
            if (Input.GetKeyDown(keyU) && canjump)
            {
                Rigidbody2D rig = GetComponent<Rigidbody2D>();
                AudioClip clip = Resources.Load<AudioClip>("Audio/jump");
                SoundPlayer.clip = clip;
                SoundPlayer.PlayOneShot(clip);
                rig.AddForce(Vector3.up * 1000f);
                canjump = false;
            }
            if (jumpimgupdate)
            {
                img = Resources.Load("Sprite and Textures/玩家/TV_Jump/Jump2", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
                if(GetComponent<player_anime>().maxHeight>transform.position.y)
                {
                    img = Resources.Load("Sprite and Textures/玩家/TV_Jump/Jump4", typeof(Sprite)) as Sprite;
                    GetComponent<SpriteRenderer>().sprite = img;
                }
            }
            if(Time.fixedTime<timestart2+0.5f)
            {
                img = Resources.Load("Sprite and Textures/玩家/TV_Jump/Jump5", typeof(Sprite)) as Sprite;
                GetComponent<SpriteRenderer>().sprite = img;
            }
            if (handleRepeater!=null)
            {
                if(Input.GetKeyDown(keyD))
                {
                    handleRepeater.transform.SetParent(null);
                    handleRepeater.GetComponent<repeater>().ishandle = false;
                    handleRepeater = null;
                }
            }
        }
    }
    void hasland()
    {
        jumpimgupdate = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground")|| col.gameObject.CompareTag("Belt"))
        {
            canjump = true;
            canMove = true;
            timestart2 = Time.fixedTime;
            Invoke("hasland", 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Belt"))
        {
            jumpimgupdate = true;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Repeater"))
        {
            if (col.GetComponent<repeater>().canhandle && !col.GetComponent<repeater>().ishandle&& col.GetComponent<repeater>().canhandlef)
            {
                Debug.Log("fgd");
                if (Input.GetKey(keyD))
                {
                    if (!col.GetComponent<repeater>().ishandle)
                    {
                        col.transform.SetParent(this.transform);
                        col.GetComponent<repeater>().ishandle = true;
                        handleRepeater = col.gameObject;
                    }
                }
            }
        }
        if (col.gameObject.CompareTag("Belt"))
        {
            transform.Translate(Vector3.right * movespeed / 8 * Time.deltaTime);
        }
    }
}
