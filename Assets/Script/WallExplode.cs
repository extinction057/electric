using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExplode : MonoBehaviour
{
    // Start is called before the first frame update
    bool isdestroy=false;
    SpriteRenderer sp;
    List<GameObject> fragments;
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        fragments = GetComponent<Explodable>().fragments;
        Invoke("destroyIt", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        /*   //     Debug.Log(isdestroy);
                if (isdestroy)
                {
                    float a = sp.color.a;
                    a = a - 0.007f;
            //        Debug.Log(a);
                    sp.color = new Color(1, 1, 1, a);
                    if (sp.color.a <= 0) Destroy(this.gameObject);
                }*/
        if (isdestroy && fragments.Count > 0)
        {
            foreach (GameObject piece in fragments)
            {
                Material mat = piece.GetComponent<MeshRenderer>().material;
                float a = mat.color.a;
                a = a - 0.01f;
                //        Debug.Log(a);
                mat.color = new Color(1, 1, 1, a);
                if (mat.color.a <= 0) Destroy(this.gameObject);
            }
        }
    }
    void destroyIt()
    {
        GetComponent<Explodable>().explode();
        isdestroy = true;
 /*       GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        GetComponent<BoxCollider2D>().enabled = false;*/
        //     Debug.Log(isdestroy);
    }
}
