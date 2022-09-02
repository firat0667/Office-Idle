using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int MoneyCount = 0;
    public int MoneyAdd = 10;
    private void OnEnable()
    {
        TriggerManager.MoneyCollected += IncreaseMoney;
        TriggerManager.OnBuyDesk += BuyArea;
    }
    private void OnDisable()
    {
        TriggerManager.MoneyCollected -= IncreaseMoney;
        TriggerManager.OnBuyDesk -= BuyArea;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IncreaseMoney()
    {
        MoneyCount += MoneyAdd;
    }
    void BuyArea()
    {
        if (TriggerManager.areaBuy != null)
        {
            if (MoneyCount >= 1)
            {
                TriggerManager.areaBuy.Buy(1);
                MoneyCount -= 1;
            }
        }
    }
}
