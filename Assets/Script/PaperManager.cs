using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject PaperPrefab;
    public Transform ExitPoint;
    public bool IsWorking;
    public float DistanceBetweenBook = 20f;
    public float PaperVelocity = 1f;
    public float StartYPos = 5f;
    public int PaperLimit = 30;
    public int PaperStack = 10;
    public float DistanceRow = 2f;
    void Start()
    {
        StartCoroutine(PrintPaper());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemovePaper()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    IEnumerator PrintPaper()
    {
        while (true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int)paperCount / PaperStack;
            if (IsWorking)
            {
                GameObject temp = Instantiate(PaperPrefab);
                temp.transform.position = new Vector3(ExitPoint.position.x-((float)rowCount/DistanceRow), StartYPos + (paperCount%PaperStack) / DistanceBetweenBook, ExitPoint.position.z);
                paperList.Add(temp);
               
                if (paperList.Count >= PaperLimit)
                {
                    IsWorking = false;
                }
            }
           
            else if(paperList.Count<PaperLimit)
            {
                IsWorking = true;
            }
            yield return new WaitForSeconds(PaperVelocity);
        }
            
        }
       

    }


