using System;
using UnityEngine;

class GameRound : ICurrentObjects, IRoundUI
{
    public Element MainElement
    {
        get
        {
            return element;
        }
        set
        {
            if (element != null)
                element.Trigger = null;
            element = value;
            if(value != null)
                element.Trigger = trigger;

            ElementReplaced?.Invoke();
        }
    }
    public bool First { get; private set; }
    public bool Pause { get; set; }
    IElement IRoundUI.MainElement => MainElement;


    public event Action ElementReplaced;
    public event Action RoundFail;
    public event Action Action;
    public event Action RoundWon;

    private bool enabled;
    private Formula formula;
    private Element element = null;
    private ElementFactory elementFactory;
    private Substance nextSubstane;

    public GameRound(Formula formula, ElementFactory elementFactory)
    {
        this.formula = formula;
        this.elementFactory = elementFactory;

        First = true;
    }
    public void Reset()
    {
        if(!First)
        {
            MainElement.Hide();
            MainElement = null;
            First = true;
        }
    }
    private void trigger(Element element2)
    {
        if (Pause)
            return;
        // первое смешивание
        if (First) 
        {
            Substance? s1 = formula.Next();
            Substance? s2 = formula.Next();
            if(MainElement.Substance == s1 && element2.Substance == s2 || MainElement.Substance == s2 && element2.Substance == s1)
            {
                IMixer mixer = MixerFactory.CreateMixer(MainElement, element2);
                mixer.Mix(MainElement, element2);
                if (mixer is Mixer m)
                {
                    Substance? ingredient = m.NewSubstance;
                    if (ingredient != null)
                    {
                        Vector3 position = Vector3.Lerp(MainElement.transform.position, element2.transform.position, 0.5f);

                        MainElement.Hide();
                        element2.Hide();

                        MainElement = elementFactory.GetElement(ingredient.Value, position);
                    }
                    else
                        throw new Exception("нет такого рецепта");
                }
                First = false;
                checkEnd();
                Action?.Invoke();
                return;
            }
        }
        // остальные смешивания
        else
        {
            if(element2.Substance == nextSubstane)
            {
                IMixer mixer = MixerFactory.CreateMixer(MainElement, element2);
                mixer.Mix(MainElement, element2);
                if (mixer is Mixer m)
                {
                    Substance? ingredient = m.NewSubstance;
                    if (ingredient != null)
                    {
                        Vector3 position = MainElement.transform.position;

                        MainElement.Hide();
                        element2.Hide();

                        MainElement = elementFactory.GetElement(ingredient.Value, position);
                    }
                    else
                        throw new Exception("нет такого рецепта");
                }
                First = false;
                checkEnd();
                Action?.Invoke();
                return;
            }
        }
        //неудачное смешивание
        First = false;
        MainElement.Bad = true;
        element2.Bad = true;
        RoundFail?.Invoke();
        formula.Reset();
    }
    private void checkEnd()
    {
        Substance? next = formula.Next();
        if (next == null)
        {
            RoundWon?.Invoke();
        }
        else
        {
            nextSubstane = next.Value;
        }
    }
    
}
