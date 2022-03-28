class Mixer : IMixer
{
    public Substance NewSubstance { get; protected set; }
    public virtual void Mix(IElement obj1, IElement obj2)
    {
        Substance? result = Recipes.SimpleMix(obj1, obj2);
        if (result != null)
        {
            NewSubstance = result.Value;
        }
    }
}
