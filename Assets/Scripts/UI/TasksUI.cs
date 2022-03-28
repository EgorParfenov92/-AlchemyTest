using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class TasksUI : MonoBehaviour
{
    [SerializeField]
    private ButtonMissionUI buttonPrefab;
    public void CreateButton(Mission mission, Action<ButtonMissionUI> method, Transform parent)
    {
        var button = Instantiate(buttonPrefab, parent);
        button.Mission = mission;
        button.Action = method;
    }
}