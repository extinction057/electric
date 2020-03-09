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
        Collider2D[] RaP = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D co in RaP)
        {
            if(co.transform!=transform&&co.transform.CompareTag("Player"))
            {
                list.Add(co.transform);
                return;
            }
        }
        foreach(Collider2D co in RaP)
        {
            if(co.transform.CompareTag("Repeater")&&!listR.Contains(co.transform))
            {
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
        list.Add(this.transform);
        listR.Add(this.transform);
        elect_dfs(list, listR);
        Debug.Log(list.Count);
        if (list.Count > 0)
        {
            islink = true;
            startCount = false;
            Debug.Log(islink);
            LR.positionCount=list.Count;
            for (int i=0;i<list.Count;i++)
            {
                LR.SetPosition(i, list[i].position); 
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
            Debug.Log("asas");
            cutTime = Time.fixedTime;
            startCount = true;
        }
        if(startCount&&!islink)
        {
            if(Time.fixedTime>cutTime+3f)
            {
                Debug.Log(Time.fixedTime);
                startCount = false;
                GetComponent<LevelChange>().gameOver();
            }
        }
    }

}
