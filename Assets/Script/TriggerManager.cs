using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void OncollectArea();
    public delegate void OnDeskAread();
    public delegate void OnMoneyArea();
    public delegate void OnBuyArea();
    public static event OncollectArea OnPaperCollect;
    public bool Iscollected,IsGiving;
    public float PaperCollectVelo = 0.5f;
    public static PaperManager PrinterManager;
    public static event OnDeskAread OnPaperGive;
    public static WorkerManager WorkerManager;
    public static event OnMoneyArea MoneyCollected;
    public static event OnBuyArea OnBuyDesk;
    public static BuyDesk areaBuy;
    
  
    void Start()
    {
        StartCoroutine(ICollect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
          
            MoneyCollected();
            Destroy(other.gameObject);
          

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            Iscollected = true;
            PrinterManager = other.gameObject.GetComponent<PaperManager>();
        }
        if (other.gameObject.CompareTag("GiveArea"))
        {
            IsGiving = true;
            WorkerManager = other.gameObject.GetComponent<WorkerManager>();

        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyDesk();
            areaBuy = other.gameObject.GetComponent<BuyDesk>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            Iscollected = false;
            PrinterManager = null;
        }
        if (other.gameObject.CompareTag("GiveArea"))
        {
            IsGiving = false;
            WorkerManager = null;

        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyDesk();
            areaBuy = null;
        }
    }
    IEnumerator ICollect()
    {
        while (true)
        {
            if (Iscollected)
            {
                OnPaperCollect();

            }
            if (IsGiving)
            {
                OnPaperGive();
            }
            yield return new WaitForSeconds(PaperCollectVelo);

        }
    }
}
