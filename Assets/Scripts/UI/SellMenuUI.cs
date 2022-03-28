using UnityEngine;
using System;

class SellMenuUI : MonoBehaviour
{
    public Action Sold { get; set; }
    public void StartMenu()
    {
        gameObject.SetActive(true);
    }
    public void StopMenu()
    {
        gameObject.SetActive(false);
    }
    public void Sell()
    {
        Sold?.Invoke();
    }
}