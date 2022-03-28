using System;

class TemperatureElement : Element, ITemperature
{
    public Temperature Temperature
    {
        get => temperature;
        set
        {
            temperature = value;
        }
    }

    private Temperature temperature = Temperature.Normal;
}
