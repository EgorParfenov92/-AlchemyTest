using System;

public class ElementObserverEventHandler : DefaultObserverEventHandler
{
    public Action<ElementObserverEventHandler> Found { get; set; }
    public Action<ElementObserverEventHandler> Lost { get; set; }

    public void Hide()
    {
        OnTrackingLost();
    }
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        transform.GetChild(0).GetComponent<Element>().Bad = false;
        Found?.Invoke(this);
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        transform.GetChild(0).GetComponent<Element>().Bad = false;
        Lost?.Invoke(this);

    }

}
