using System.Collections.Generic;
using UnityEngine;

class VisualManager : MonoBehaviour
{
    public ICurrentObjects CurrentObjects
    {
        get => currentObjects;
        set
        {
            if(currentElemens.Count != 0)
            {
                value.MainElement = currentElemens[0].transform.GetChild(0).GetComponent<Element>();
            }
            currentObjects = value;
        }
    }
    private ICurrentObjects currentObjects;
    private List<ElementObserverEventHandler> currentElemens = new List<ElementObserverEventHandler> { };
    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            var elementObserver = transform.GetChild(i).GetComponent<ElementObserverEventHandler>();
            elementObserver.Found = FoundObj;
            elementObserver.Lost = LostObj;
        }
    }
    private void FoundObj(ElementObserverEventHandler elementObserver)
    {
        currentElemens.Add(elementObserver);
        if (CurrentObjects != null)
        {
            if (CurrentObjects.MainElement == null && CurrentObjects.First)
            {
                CurrentObjects.MainElement = elementObserver.transform.GetChild(0).GetComponent<Element>();
            }
        }
        
    }
    private void LostObj(ElementObserverEventHandler elementObserver)
    {
        if (currentElemens.Contains(elementObserver))
        {
            if (CurrentObjects != null)
            {
                if (CurrentObjects.First)
                {
                    if (currentElemens.Count == 1)
                    {
                        CurrentObjects.MainElement = null;
                    }
                    else
                    {
                        CurrentObjects.MainElement = currentElemens[currentElemens.Count - 2].transform.GetChild(0).GetComponent<Element>();
                    }
                }
            }
            currentElemens.Remove(elementObserver);
        }
        
    }
}