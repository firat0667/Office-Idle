using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> WorkAreaPapers = new List<GameObject>();
    public List<GameObject> MoneyList = new List<GameObject>();
    public Transform PaperPoint,MoneyPoint;
    public GameObject PaperPrefab,MoneyPrefab;
    public int DisanceBook = 14;
    public float Ypos,DollarYpos;
    public float MoneyVelo = 0.5f;
    void Start()
    {
        StartCoroutine(IgeneratorMoney());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetPaper()
    {
        GameObject temp = Instantiate(PaperPrefab);
        temp.transform.position = new Vector3(PaperPoint.position.x,(Ypos+(float)WorkAreaPapers.Count/DisanceBook), PaperPoint.position.z);
        WorkAreaPapers.Add(temp);
       
    }
    IEnumerator IgeneratorMoney()
    {
        while (true)
        {
            if (WorkAreaPapers.Count > 0)
            {
                GameObject temp = Instantiate(MoneyPrefab);
                temp.transform.position = new Vector3(MoneyPoint.position.x, (DollarYpos + (float)MoneyList.Count / DisanceBook), MoneyPoint.position.z);
                MoneyList.Add(temp);
                RemovePaper();
            }
            yield return new WaitForSeconds(MoneyVelo);
        }
       
    }
    public void RemovePaper()
    {
        if (WorkAreaPapers.Count > 0)
        {
            Destroy(WorkAreaPapers[WorkAreaPapers.Count - 1]);
            WorkAreaPapers.RemoveAt(WorkAreaPapers.Count - 1);
        }
    }
}
