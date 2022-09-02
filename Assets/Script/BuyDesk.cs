using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDesk : MonoBehaviour
{
    public GameObject Desk;
    public GameObject BuyGameObject;
    public float Cost, Current,progress;
    public Image ProgressImage;
    public void Buy(int moneyAmount)
    {
        Current += moneyAmount;
        progress = Current / Cost;
        ProgressImage.fillAmount = progress;
        if (progress >= 1)
        {
            BuyGameObject.SetActive(false);
            Desk.SetActive(true);
            this.enabled = false;
        }
    }
}
