using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallExplodeChain : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    bool isdestroy = false;
    bool ison = true;
    SpriteRenderer sp;
    GameObject[] trap;
    int i = 0;
    void Awake()
    {
        //    sp = GetComponent<SpriteRenderer>();
        //  Invoke("destroyIt", 0.2f);
        trap = GameObject.FindGameObjectsWithTag("Trap").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        //     Debug.Log(isdestroy);
        if (isdestroy&&i<27)
        {
            foreach(GameObject tr in trap)
            {
//                Debug.Log(i);
                Invoke("destroyChain", i * 0.8f);
                i++;
            }
        }
    }
    private void destroyChain()
    {
        Debug.Log(i);
        trap[i-27].AddComponent<WallExplode>();
        i++;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Repeater") && ison)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprite and Textures/开关/switch_on", typeof(Sprite)) as Sprite;
            isdestroy = true;
        }
    }
}
