using TMPro;
using UnityEngine;
using System;

class GoldUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private int numberToWin;
    public Action WinGame { get; set; }
    private int prizRound = 0;
    private void Start()
    {
        text.text = $"{prizRound}/{numberToWin}";
    }
    public void Add(int priz)
    {
        this.prizRound += priz;
    }
    public void Set()
    {
        text.text = $"{prizRound}/{numberToWin}";
        if(prizRound >= numberToWin)
        {
            WinGame?.Invoke();
        }
    }
}