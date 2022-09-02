using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> CollectableList = new List<GameObject>();
    public GameObject PaperPrafab;
    public Transform collectibleTransform;
    int paperLimit = 10;
    public int Ypos = 20;
    public float YposAmount = 0.5f;

    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += GetPaper;
        TriggerManager.OnPaperGive += GiveBook;
    }
    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= GetPaper;
        TriggerManager.OnPaperGive -= GiveBook;
    }
    void GetPaper()
    {
        if (CollectableList.Count < paperLimit)
        {
            GameObject temp = Instantiate(PaperPrafab, collectibleTransform);
            temp.transform.position = new Vector3(collectibleTransform.position.x,
               YposAmount+((float)CollectableList.Count / Ypos), collectibleTransform.position.z
                );
            CollectableList.Add(temp);
            if (TriggerManager.PrinterManager != null)
            {
                TriggerManager.PrinterManager.RemovePaper();
            }
        }
    }
    public void GiveBook()
    {
        if (CollectableList.Count > 0)
        {
            TriggerManager.WorkerManager.GetPaper();
            RemovePaper();
        }
    }
    public void RemovePaper()
    {
        if (CollectableList.Count > 0)
        {
            Destroy(CollectableList[CollectableList.Count - 1]);
            CollectableList.RemoveAt(CollectableList.Count - 1);
        }
    }
}
