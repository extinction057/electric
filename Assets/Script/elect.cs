using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class elect : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 8;
    bool islink=true;
    LineRenderer LR;
    public int num;
    float cutTime;
    bool startCount=false;
    void Awake()
    {
        LR = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        gameOver();
    }

    void elect_dfs(List<Transform> list,List<Transform> listR)
    {
        Transform lastTran = list.Last();
        Collider2D[] RaP = Physics2D.OverlapCircleAll(lastTran.position, radius);
        foreach(Collider2D co in RaP)
        {
            if(co.gameObject.transform!=transform&&co.gameObject.CompareTag("Player"))
            {
                Debug.Log("sort1");
                list.Add(co.transform);
                return;
            }
        }
        foreach(Collider2D co in RaP)
        {
            if(co.gameObject.CompareTag("Repeater")&&!listR.Contains(co.transform))
            {
                Debug.Log("sort2");
                listR.Add(co.transform);
                list.Add(co.transform);
                elect_dfs(list, listR);
                if(list.Last().CompareTag("Player")&&list.Count>1)
                {
                    return;
                }
            }
        }
        list.Remove(lastTran);
        listR.Remove(lastTran);
    }
    private void DrawLine()
    {
        if (num == 2)
        {
            return;
        }
        List<Transform> list = new List<Transform>();
        List<Transform> listR = new List<Transform>();
        List<Vector3> listRandom = new List<Vector3>();
        list.Add(this.transform);
        listR.Add(this.transform);
        elect_dfs(list, listR);
        LineRandom(list,listRandom);
 //       Debug.Log(list.Count);
        if (listRandom.Count > 0)
        {
            islink = true;
            startCount = false;
            Debug.Log(islink);
            LR.positionCount=listRandom.Count;
            for (int i=0;i<listRandom.Count;i++)
            {
                LR.SetPosition(i, listRandom[i]); 
            }
            return;
        }
        islink = false;
        LR.positionCount = 0;
    }
    void gameOver()
    {
        if(!islink&&!startCount)
        {
            cutTime = Time.fixedTime;
            startCount = true;
        }
        if(startCount&&!islink)
        {
            if(Time.fixedTime>cutTime+3f)
            {
                Debug.Log(Time.fixedTime);
                startCount = false;
                GetComponent<GameOver>().gameOver();
            }
        }
    }
    void LineRandom(List<Transform> list,List<Vector3> listRandom)
    {
        int n = list.Count;
        for(int i=0;i<n-1;i++)
        {
            float k;
            k = (list[i + 1].position.y - list[i].position.y) / (list[i + 1].position.x - list[i].position.x);
            listRandom.Add(list[i].position);
            for(int j=1;j<10;j++)
            {
                float r_y = Random.Range(-0.3f, 0.3f);
                float x = list[i].position.x + (list[i + 1].position.x - list[i].position.x) / 10 * j;
                float y = list[i].position.y + (list[i + 1].position.x - list[i].position.x) / 10 * j * k + r_y;
                Vector3 node = new Vector3(x, y, 0);
                listRandom.Add(node);
            }
        }
        if(n>0) listRandom.Add(list[n-1].position);
    }
}
