using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
class ElementFactory : ScriptableObject
{
    [SerializeField]
    private Element healingPotion;
    [SerializeField]
    private Element manaPotion;
    [SerializeField]
    private Element strenghtPotion;
    [SerializeField]
    private Element invisibilityPotion;
    [SerializeField]
    private Element slurry;
    public Element GetElement(Substance substance, Vector3 position)
    {
        switch (substance)
        {
            case Substance.healingPotion:
                return Instantiate(healingPotion, position, Quaternion.identity);
            case Substance.manaPotion:
                return Instantiate(manaPotion, position, Quaternion.identity);
            case Substance.strenghtPotion:
                return Instantiate(strenghtPotion, position, Quaternion.identity);
            case Substance.invisibilityPotion:
                return Instantiate(invisibilityPotion, position, Quaternion.identity);
            case Substance.slurry:
                return Instantiate(slurry, position, Quaternion.identity);
            default:
                throw new System.Exception();
        }
    }
}