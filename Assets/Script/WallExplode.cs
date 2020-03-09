using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExplode : MonoBehaviour
{
    // Start is called before the first frame update
    bool isdestroy=false;
    SpriteRenderer sp;
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        Invoke("destroyIt", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
   //     Debug.Log(isdestroy);
        if (isdestroy)
        {
            float a = sp.color.a;
            a = a - 0.007f;
    //        Debug.Log(a);
            sp.color = new Color(1, 1, 1, a);
            if (sp.color.a <= 0) Destroy(this.gameObject);
        }
    }
    void destroyIt()
    {
        isdestroy = true;
   //     Debug.Log(isdestroy);
    }
}
