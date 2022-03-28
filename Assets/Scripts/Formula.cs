using System;
using System.Collections.Generic;

sealed class Formula : Iingredients
{
    private List<Substance> ingredients = new List<Substance> { };
    private int current = -1;
    public Formula(IEnumerable<Substance> ingredients)
    {
        this.ingredients.AddRange(ingredients);
    }
    public Substance? Next()
    {
        current++;
        if (current >= ingredients.Count)
        {
            return null;
        }
        return ingredients[current];
    }
    public void Reset()
    {
        current = -1;
    }
    public IEnumerable<Substance> GetSteps()
    {
        return ingredients;
    }
}
