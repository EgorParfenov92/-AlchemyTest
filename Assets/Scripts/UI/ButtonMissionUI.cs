using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class ButtonMissionUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image image;
    public Action<ButtonMissionUI> Action;
    public Mission Mission { get; set; }
    private void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        image = GetComponent<Image>();
        text.text = Mission.Result.ToString();
    }
    public void Execute()
    {
        Action?.Invoke(this);
    }
    public void Del()
    {
        Destroy(gameObject);
    }
    public void Fail()
    {
        image.color = new Color(0, 0, 0, 0.5f);
    }
    public void Success()
    {
        image.color = new Color(0, 200, 30, 0.5f);
    }
}
