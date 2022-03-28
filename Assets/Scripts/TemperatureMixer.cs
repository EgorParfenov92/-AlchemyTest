class TemperatureMixer : Mixer
{
    public override void Mix(IElement obj1, IElement obj2)
    {
        Substance? result = null;
        if (obj1 is ITemperature t && t.Temperature != Temperature.Normal)
        {
            result = Recipes.TemperatureMix((ITemperature)obj1, obj2);
        }
        else if(obj2 is ITemperature t2 && t2.Temperature != Temperature.Normal)
        {
            result = Recipes.TemperatureMix((ITemperature)obj2, obj1);
        }
        else
        {
            result = Recipes.SimpleMix(obj1, obj2);
        }
        if (result != null)
        {
            NewSubstance = result.Value;
        }
    }
}
