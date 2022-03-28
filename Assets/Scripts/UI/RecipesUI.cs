using System.Collections.Generic;
using UnityEngine;

class RecipesUI : MonoBehaviour
{
    [SerializeField]
    private IngredientUI prefab;

    private Iingredients progress;
    private List<IngredientUI> ingredients = new List<IngredientUI> { };
    private int currentNumber = -1;
    public void SetRecipe(Iingredients progress)
    {
        this.progress = progress;
        foreach (Substance s in progress.GetSteps())
        {
            var ingredient = Instantiate(prefab, transform);
            ingredient.SetText(s);
            ingredients.Add(ingredient);
        }
    }
    public void Fail()
    {
        currentNumber++;
        ingredients[currentNumber].Fail();
    }
    public void ResetUI()
    {
        currentNumber = -1;
        foreach(IngredientUI i in ingredients)
        {
            Destroy(i.gameObject);
        }
        ingredients.Clear();
        progress = null;
    }
    public void Next()
    {
        currentNumber++;
        ingredients[currentNumber].Success();
        if(currentNumber == 0)
            Next();
    }
}
