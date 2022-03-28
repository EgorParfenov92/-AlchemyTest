using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//класс гейм - это точка входа в игру. в нем содержатся основные модули (VisualManager, UIManager)
//он создает новые GameRound (на основе missions) и осуществляет взаимодействие между модулями

class Game : MonoBehaviour, IGame
{
    [SerializeField]
    private Mission[] missions;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    public VisualManager visualManager;
    [SerializeField]
    private ElementFactory elementFactory;

    private GameRound currentRound;
    private Mission currentMission;
    private Dictionary<Mission, GameRound> activeMissions;
    private Queue<Mission> missionsQueue = new Queue<Mission> { };
    private int roundNumber = -1;
    
    private void Awake()
    {
        missionsQueue = new Queue<Mission>(missions);
        activeMissions = new Dictionary<Mission, GameRound> { };
        StartCoroutine(addMission());

        uiManager.Game = this;
    }
    private IEnumerator addMission()
    {
        while(missionsQueue.Count != 0)
        {
            Mission m = missionsQueue.Dequeue();
            yield return new WaitForSeconds(m.Delay);
            roundNumber++;
            m.SetID(roundNumber);
            activeMissions.Add(m, new GameRound(m.Formula, elementFactory));
            uiManager.AddMission(m);
        }
    }
    public IRoundUI SelectMission(Mission mission)
    {
        CompliteMission();
        currentRound = activeMissions[mission];
        currentMission = mission;
        visualManager.CurrentObjects = currentRound;
        return currentRound;
    }
    public void CompliteMission()
    {
        if (currentRound != null)
        {
            currentRound.Reset();
            activeMissions.Remove(currentMission);
            currentRound = null;
        }
    }
    public void Pause(bool value)
    {
        if (value)
        {
            StopCoroutine(addMission());
        }
        else
        {
            StartCoroutine(addMission());
        }
    }
}
