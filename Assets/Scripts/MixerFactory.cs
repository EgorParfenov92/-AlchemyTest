using System.Collections.Generic;

class MixerFactory
{
    private static ChangeTemerature changeTemerature => new ChangeTemerature();
    private static Mixer mixer => new Mixer();
    private static TemperatureMixer temperatureMixer => new TemperatureMixer();

    private static Dictionary<(ElementType, ElementType), IMixer> mixers = new Dictionary<(ElementType, ElementType), IMixer>
    {
        { (ElementType.Crystal, ElementType.Temperature),  changeTemerature},
        { (ElementType.Temperature, ElementType.Crystal),  changeTemerature},
        { (ElementType.Simple, ElementType.Simple),  mixer},
        { (ElementType.Temperature, ElementType.Simple),  temperatureMixer},
        { (ElementType.Simple, ElementType.Temperature),  temperatureMixer},
        { (ElementType.Temperature, ElementType.Temperature),  temperatureMixer},
    };
    public static IMixer CreateMixer(IElement element1, IElement element2)
    {
        return mixers[(element1.ElementType, element2.ElementType)];
    }
}