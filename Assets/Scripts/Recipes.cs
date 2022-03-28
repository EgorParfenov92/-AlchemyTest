using System.Collections.Generic;

class Recipes
{
    private static Dictionary<(Substance, Substance), Substance> sipleRecepes = new Dictionary<(Substance, Substance), Substance>
    {
        { (Substance.mushroom, Substance.blood), Substance.healingPotion},
        { (Substance.holyWater, Substance.mushroom), Substance.manaPotion},
        { (Substance.slurry, Substance.mushroom), Substance.invisibilityPotion},
    };
    private static Dictionary<(Substance, Temperature, Substance), Substance> temperaturePecepes = new Dictionary<(Substance, Temperature, Substance), Substance>
    {
        { (Substance.holyWater, Temperature.Hot, Substance.mushroom), Substance.strenghtPotion},
        { (Substance.blood, Temperature.Cold, Substance.holyWater), Substance.slurry},
    };
    public static Substance? SimpleMix(IElement substance1, IElement substance2)
    {
        if (sipleRecepes.ContainsKey((substance1.Substance, substance2.Substance)))
        {
            return sipleRecepes[(substance1.Substance, substance2.Substance)];
        }
        else if (sipleRecepes.ContainsKey((substance2.Substance, substance1.Substance)))
        {
            return sipleRecepes[(substance2.Substance, substance1.Substance)];
        }
        else
            return null;
    }
    public static Substance? TemperatureMix(ITemperature substance1, IElement substance2)
    {
        if (temperaturePecepes.ContainsKey((substance1.Substance, substance1.Temperature, substance2.Substance)))
        {
            return temperaturePecepes[(substance1.Substance, substance1.Temperature, substance2.Substance)];
        }
        else
            return null;
    }
}
