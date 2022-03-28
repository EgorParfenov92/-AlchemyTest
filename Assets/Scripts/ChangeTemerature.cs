class ChangeTemerature : IMixer
{
    public virtual void Mix(IElement obj1, IElement obj2)
    {
        if (obj1.Substance == Substance.heatingCrystal)
        {
            if (obj2 is ITemperature t)
            {
                t.Temperature = raise(t.Temperature);
            }
        }
        else if (obj1.Substance == Substance.coolingCrystal)
        {
            if (obj2 is ITemperature t)
            {
                t.Temperature = downgrade(t.Temperature);
            }
        }
        else if(obj1 is ITemperature t)
        {
            if (obj2.Substance == Substance.heatingCrystal)
            {
                t.Temperature = raise(t.Temperature);
            }
            else
            {
                t.Temperature = downgrade(t.Temperature);
            }
        }
        else
            throw new System.Exception();
    }
    private Temperature raise(Temperature temperature)
    {
        switch (temperature)
        {
            case Temperature.Cold:
                return Temperature.Normal;
            case Temperature.Normal:
                return Temperature.Hot;
            case Temperature.Hot:
                return Temperature.Hot;
            default:
                throw new System.Exception();
        }
    }
    private Temperature downgrade(Temperature temperature)
    {
        switch (temperature)
        {
            case Temperature.Cold:
                return Temperature.Cold;
            case Temperature.Normal:
                return Temperature.Cold;
            case Temperature.Hot:
                return Temperature.Normal;
            default:
                throw new System.Exception();
        }
    }
}
