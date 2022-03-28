using System;
using TMPro;
using UnityEngine;

class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public Action Fail { get; set; }
    private float time;
    private bool start = false;
    private void Update()
    {
        if (!start)
            return;
        time -= Time.deltaTime;
        text.text = Math.Round(time).ToString();
        if(time <= 0)
        {
            ResetTimer();
            Fail?.Invoke();
        }
    }
    public void Pause(bool value)
    {
        start = !value;
    }
    public void Stop()
    {
        start = false;
    }
    public void StartTimer(int time)
    {
        this.time = time;
        start = true;
    }
    public void ResetTimer()
    {
        start = false;
        text.text = "";
    }
}
