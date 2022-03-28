using UnityEngine;
using UnityEngine.UI;

class ElementInfoUI : MonoBehaviour
{
    private IRoundUI round;
    [SerializeField]
    private Sprite hot;
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite cold;
    [SerializeField]
    private Image image;
    public void SetRound(IRoundUI round)
    {
        this.round = round;
    }
    public void ElementReplaced()
    {
        if (round.MainElement != null)
        {
            Debug.Log(round.MainElement.Substance);

            if (round.MainElement.ElementType == ElementType.Temperature)
            {
                gameObject.SetActive(true);
                if(round.MainElement is ITemperature t)
                {
                    setSprite(t.Temperature);
                    return;
                }
               
            }
        }
        gameObject.SetActive(false);
    }
    public void Mix()
    {
        if (round.MainElement is ITemperature t)
        {
            setSprite(t.Temperature);
        }
    }
    private void setSprite(Temperature temperature)
    {
        switch (temperature)
        {
            case Temperature.Normal:
                image.sprite = normal;
                return;
            case Temperature.Hot:
                image.sprite = hot;
                return;
            case Temperature.Cold:
                image.sprite = cold;
                return;
        }
    }
    public void ResetUI()
    {
        round = null;
    }
}