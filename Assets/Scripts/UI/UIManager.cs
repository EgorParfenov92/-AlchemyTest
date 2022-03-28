using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class UIManager : MonoBehaviour
{
    [SerializeField]
    private GoldUI goldUI;
    [SerializeField]
    private TimerUI timerUI;
    [SerializeField]
    private TasksUI tsksUI;
    [SerializeField]
    private RecipesUI recipesUI;
    [SerializeField]
    private ElementInfoUI elementInfoUI;
    [SerializeField]
    private SellMenuUI sellMenu;
    [Space(5)]
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private MenuUI winMenu;


    public IGame Game { get; set; }
    private ButtonMissionUI currentButton;
    private IRoundUI currentRound;

    private bool ready = true;
    private void Start()
    {
        timerUI.Fail = missionFailed;
        goldUI.WinGame = winGame;
        sellMenu.Sold = sellPotion;
    }
    public void AddMission(Mission mission)
    {
        tsksUI.CreateButton(mission, SelectMission, tsksUI.transform);
    }
    private void SelectMission(ButtonMissionUI missionUI)
    {
        if (!ready)
            return;
        Debug.Log("новая миссия");

        if (currentRound != null)
        {
            currentRound.ElementReplaced -= elementInfoUI.ElementReplaced;
            currentRound.RoundFail -= missionFailed;
            currentRound.RoundWon -= missionComplete;
            currentRound.Action -= mix;

            currentRound = null;

            recipesUI.ResetUI();
            elementInfoUI.ResetUI();
            currentButton.Del();
        }
        currentButton = missionUI;
        currentRound = Game.SelectMission(missionUI.Mission);
        elementInfoUI.SetRound(currentRound);

        currentRound.ElementReplaced += elementInfoUI.ElementReplaced;
        currentRound.RoundFail += missionFailed;
        currentRound.RoundWon += missionComplete;
        currentRound.Action += mix;

        goldUI.Add(missionUI.Mission.Reward);
        timerUI.StartTimer(missionUI.Mission.TimeToComplete);
        recipesUI.SetRecipe(missionUI.Mission.Formula);

        ready = false;
    }
    private void missionComplete()
    {
        Debug.Log("миссия выполнена");
        currentRound.Pause = true;
        currentButton.Success();
        timerUI.Stop();

        sellMenu.StartMenu();
    }
    private void sellPotion()
    {
        goldUI.Set();
        sellMenu.StopMenu();
        Game.CompliteMission();

        ready = true;
    }
    private void missionFailed()
    {
        Debug.Log("миссия провалена");
        currentRound.Pause = true;
        recipesUI.Fail();
        currentButton.Fail();

        ready = true;
    }
    private void mix()
    {
        Debug.Log("произошло смешивание");
        recipesUI.Next();
        elementInfoUI.Mix();
    }
    public void Pause()
    {
        background.SetActive(true);
        Game.Pause(true);
        timerUI.Pause(true);
        if (currentRound != null)
            currentRound.Pause = true;
    }
    public void Unpause()
    {
        background.SetActive(false);
        Game.Pause(false);
        timerUI.Pause(false);
        if (currentRound != null)
            currentRound.Pause = false;
    }
    private void winGame()
    {
        ready = false;
        Pause();
        winMenu.EnableMenu();
    }
}