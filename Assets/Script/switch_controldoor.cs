using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_controldoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door_u;
    public GameObject door_d;
    bool ison = true;
    bool doorOpen = false;
    bool doorExist = true;
    public float udoor;
    public float ddoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen&&doorExist)
        {
            door_u.transform.Translate(Vector3.up * 4 * Time.deltaTime);
            door_d.transform.Translate(Vector3.down * 4 * Time.deltaTime);
        }
        if (door_u.transform.position.y >= udoor&&doorExist)
        {
            doorExist = false;
            door_u.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (door_d.transform.position.y <= ddoor || !doorExist) door_d.GetComponent<SpriteRenderer>().sprite = null;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Repeater")&& ison)
        {
            GetComponent<SpriteRenderer>().sprite= Resources.Load("Sprite and Textures/开关/switch_on", typeof(Sprite)) as Sprite;
            doorOpen = true;
        }
    }
}
